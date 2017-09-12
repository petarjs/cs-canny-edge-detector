using System;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;

namespace SignaliEdge
{
    public class ImageHandler
    {
        private string _bitmapPath;
        private Bitmap _currentBitmap;
        private Bitmap _originalBitmap;
        private bool isGrayscale = false;
        byte bitsPerPixel;

        /// <summary>
        /// Used to avoid transforming the image to grayscale more than once
        /// </summary>
        public bool IsGrayscale { 
            get { return isGrayscale; } 
            private set { isGrayscale = value; } 
        }

        /// <summary>
        /// Bitmap used to store the original version of image,
        /// without any transformations.
        /// </summary>
        public Bitmap OriginalBitmap
        {
            set { _originalBitmap = value; }
            get { return _originalBitmap; }
        }

        /// <summary>
        /// Bitmap used to store modified version of the OriginalBitmap.
        /// This bitmap is initially same as OriginalBitmap, but after
        /// processing holds the bitmap with found edges.
        /// </summary>
        public Bitmap CurrentBitmap
        {
            get { return _currentBitmap; }
            set { _currentBitmap = value; isGrayscale = false; }
        }

        /// <summary>
        /// Path to the image being processed
        /// </summary>
        public string BitmapPath
        {
            get { return _bitmapPath; }
            set { _bitmapPath = value; }
        }

        public byte GetBitsPerPixel(PixelFormat pf)
        {
            byte BitsPerPixel;
            switch(pf)       
              {
                 case PixelFormat.Format8bppIndexed:
                    BitsPerPixel = 8;
                    break;
                 case PixelFormat.Format24bppRgb:
                    BitsPerPixel = 24;
                    break;
                 case PixelFormat.Format32bppArgb:
                 case PixelFormat.Format32bppPArgb:
                    BitsPerPixel = 32;
                    break;
                 default:
                    BitsPerPixel = 0;
                    break;      
             }
            return BitsPerPixel;
        }

        /// <summary>
        /// Makes the current bitmap grayscale
        /// </summary>
        public unsafe void SetGrayscale()
        {
            if (CurrentBitmap == null || isGrayscale) return;

            BitmapData bData = _currentBitmap.LockBits(new Rectangle(0, 0, _currentBitmap.Width, _currentBitmap.Height), ImageLockMode.ReadWrite, _currentBitmap.PixelFormat);
            bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);
            byte* scan0 = (byte*)bData.Scan0.ToPointer();

            byte* data;
            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;

                    if (bitsPerPixel >= 24)
                    {
                        var gray = (byte)(.299 * data[2] + .587 * data[1] + .114 * data[0]);

                        data[0] = gray;
                        data[1] = gray;
                        data[2] = gray;
                        //data is a pointer to the first byte of the 3-byte color data    
                    }
                    
                }
            }

            _currentBitmap.UnlockBits(bData);
            isGrayscale = true;
        }

        /// <summary>
        /// Returns the normalized version of original bitmap
        /// </summary>
        /// <returns>Matrix of doubles between 0s and 1s</returns>
        public unsafe double[,] GetNormalizedMatrix()
        {
            if (_originalBitmap == null) return null;

            BitmapData bData = _originalBitmap.LockBits(new Rectangle(0, 0, _originalBitmap.Width, _originalBitmap.Height), ImageLockMode.ReadWrite, _originalBitmap.PixelFormat);
            bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);
            byte* scan0 = (byte*)bData.Scan0.ToPointer();

            var normalizedMatrix = new double[_originalBitmap.Width, _originalBitmap.Height];

            byte* data;
            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;

                    normalizedMatrix[j, i] = data[0] / 255d;
                    //data is a pointer to the first byte of the 3-byte color data
                }
            }

            _originalBitmap.UnlockBits(bData);

            return normalizedMatrix;
        }

        /// <summary>
        /// Fills the current bitmap with denormalized values
        /// from passed matrix.
        /// Passed matrix consists only of 0s and 1s.
        /// </summary>
        /// <param name="norm">Matrix with values between 0 and 1</param>
        public unsafe void DenormalizeCurrent(double[,] norm)
        {
            if(norm == null) return;
            int n = norm.GetLength(0);
            int m = norm.GetLength(1);

            if (m != _currentBitmap.Height || n != _currentBitmap.Width)
            {
                throw new Exception("Sizes don't match.");
            }


            BitmapData bData = _currentBitmap.LockBits(new Rectangle(0, 0, _currentBitmap.Width, _currentBitmap.Height), ImageLockMode.ReadWrite, _currentBitmap.PixelFormat);
            bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);
            byte* scan0 = (byte*)bData.Scan0.ToPointer();

            byte* data;
            for (int i = 0; i < bData.Height; ++i)
            {
                for (int j = 0; j < bData.Width; ++j)
                {
                    data = scan0 + i * bData.Stride + j * bitsPerPixel / 8;

                    byte newCol = norm[j, i] == 0 ? (byte)0 : (byte)255;
                    if (bitsPerPixel >= 24)
                    {
                        data[0] = newCol;
                        data[1] = newCol;
                        data[2] = newCol;
                        //data is a pointer to the first byte of the 3-byte color data
                    }
                    else
                    {
                        data[0] = newCol;
                    }
                }
            }

            _currentBitmap.UnlockBits(bData);
        }

        public void CleanUp()
        {
            _currentBitmap = null;
            _originalBitmap = null;
            isGrayscale = false;
            bitsPerPixel = 0;
            _bitmapPath = "";
            GC.Collect();
        }

    }
}


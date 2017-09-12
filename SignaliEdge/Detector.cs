using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignaliEdge
{
    class Detector
    {
        public Detector()
        {
        }

        private bool _maxPrecision;
        public bool MaxPrecision { 
            get { return _maxPrecision; } 
            set { _maxPrecision = value; } 
        }

        private double ut, lt;
        public double LowerTreshold {
            get { return lt; }
            set { lt = value; } 
        }
        public double UpperTreshold {
            get { return ut; }
            set { ut = value; }
        }
        private double[,] xIzvod;
        private double[,] yIzvod;
        private double[,] magnitudaGradijenta;
        private double[,] smerGradijenta;
        private double[,] xMatrica = { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } };
        private double[,] yMatrica = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
        private double[,] gaussMatrica = {
                                            {0.0121, 0.0261, 0.0337, 0.0261, 0.0121},
                                            {0.0261, 0.0561, 0.0724, 0.0561, 0.0261},
                                            {0.0337, 0.0724, 0.0935, 0.0724, 0.0337},
                                            {0.0261, 0.0561, 0.0724, 0.0561, 0.0261},
                                            {0.0121, 0.0261, 0.0337, 0.0261, 0.0121}
                                        };

        private double[,] konvolucija(double[,] slikaUlaz, double[,] kernel, int poluprecnik)
        {
            if (slikaUlaz == null) return null;

            int yPoz = slikaUlaz.GetLength(1);
            int xPoz = slikaUlaz.GetLength(0);

            double[,] slikaIzlaz = new double[xPoz, yPoz];

            //for (int i = 0; i < xPoz; i++)
            Parallel.For(0, xPoz, i => {
                for (int j = 0; j < yPoz; j++)
                {
                    double novaVrednost = 0;
                    for (int innerI = i - poluprecnik; innerI < i + poluprecnik + 1; innerI++)
                        for (int innerJ = j - poluprecnik; innerJ < j + poluprecnik + 1; innerJ++)
                        {
                            int idxX = (innerI + xPoz) % xPoz;
                            int idxY = (innerJ + yPoz) % yPoz;

                            int kernx = innerI - (i - poluprecnik);
                            int kerny = innerJ - (j - poluprecnik);
                            novaVrednost += slikaUlaz[idxX, idxY] * kernel[kernx, kerny];
                        }

                    slikaIzlaz[i, j] = novaVrednost;
                }
            });


            return slikaIzlaz;
        }

        public double[,] prosiriMatricu(double[,] matrica, int prosirenje)
        {
            if (matrica == null) return null;

            int x = matrica.GetLength(0), y = matrica.GetLength(1);
            /*double[,] prosirena = new double[x * 3, y * 3];
            for (int i = 0; i < prosirena.GetLength(0); i++)
                for (int j = 0; j < prosirena.GetLength(1); j++)
                {
                    int modJ=j % y;
                    int modI=i % x;
                    prosirena[i, j] = matrica[modI, modJ];
                }
            double[,] vracaSe = new double[x + 2 * prosirenje, y + 2 * prosirenje];
            for (int i = x - prosirenje; i < 2 * x + prosirenje; i++)
                for (int j = y - prosirenje; j < 2 * y + prosirenje; j++)
                {
                    int razlikaI = i - x + prosirenje;
                    int razlikaJ = j - y + prosirenje;
                    vracaSe[razlikaI, razlikaJ] = prosirena[i, j];
                }
            return vracaSe;*/
            double[,] vracaSe = new double[x + 2 * prosirenje, y + 2 * prosirenje];
            for (int i = -prosirenje; i < x + prosirenje-1; i++)
                for (int j = -prosirenje; j < y + prosirenje-1; j++)
                {
                    var ii = (i + x)%x;
                    int jj = (j + y)%y;
                    vracaSe[i+2, j+2] = matrica[ii, jj];
                }
            return vracaSe;
        }

        public double[,] Detection(double[,] normSlika, int precision)
        {

            if (normSlika == null) return null;
            int blurx, blury;

            double[,] blurovana;
            try
            {
                blurovana = konvolucija(normSlika, gaussMatrica, 2);

                blurx = blurovana.GetLength(0); blury = blurovana.GetLength(1);

                xIzvod = konvolucija(blurovana, xMatrica, 1);
                yIzvod = konvolucija(blurovana, yMatrica, 1);
            }
            catch (OutOfMemoryException)
            {
                throw;
            }

            int xIzvodx=xIzvod.GetLength(0), xIzvody = xIzvod.GetLength(1);
            magnitudaGradijenta = new double[xIzvodx, xIzvody];
            smerGradijenta = new double[xIzvodx, xIzvody];

            for (int x = 0; x < blurx; x++)
            {
                for (int y = 0; y < blury; y++)
                {
                    magnitudaGradijenta[x, y] = Math.Sqrt(xIzvod[x, y] * xIzvod[x, y] + yIzvod[x, y] * yIzvod[x, y]);
                    double pom = Math.Atan2(xIzvod[x, y], yIzvod[x, y]);
                    if ((pom >= -Math.PI / 8 && pom < Math.PI / 8) || (pom <= -7 * Math.PI / 8 && pom > 7 * Math.PI / 8))
                        smerGradijenta[x, y] = 0;
                    else if ((pom >= Math.PI / 8 && pom < 3 * Math.PI / 8) || (pom <= -5 * Math.PI / 8 && pom > -7 * Math.PI / 8))
                        smerGradijenta[x, y] = Math.PI / 4;
                    else if ((pom >= 3 * Math.PI / 8 && pom <= 5 * Math.PI / 8) || (-3 * Math.PI / 8 >= pom && pom > -5 * Math.PI / 8))
                        smerGradijenta[x, y] = Math.PI / 2;
                    else if ((pom < -Math.PI / 8 && pom >= -3 * Math.PI / 8) || (pom > 5 * Math.PI / 8 && pom <= 7 * Math.PI / 8))
                        smerGradijenta[x, y] = -Math.PI / 4;
                }
            }

            var max = maxi(magnitudaGradijenta);
            for (int i = 0; i < xIzvodx; i++)
            {
                for (int j = 0; j < xIzvody; j++)
                {
                    magnitudaGradijenta[i, j] /= max;
                }
            }

            if (ut == 0 && lt == 0) OdrediPragove(blurx, blury);

            for (int i = 0; i < xIzvodx; i++)
            {
                for (int j = 0; j < xIzvody; j++)
                {
                    magnitudaGradijenta[i, j] = magnitudaGradijenta[i, j] < lt ? 0 : magnitudaGradijenta[i, j];
                }
            }

            for (var x = 1; x < blurx - 1; x++)
            {
                for (var y = 1; y < blury - 1; y++)
                {

                        if (smerGradijenta[x, y] == 0 && (magnitudaGradijenta[x, y] <= magnitudaGradijenta[x - 1, y] || magnitudaGradijenta[x, y] <= magnitudaGradijenta[x + 1, y]))

                            magnitudaGradijenta[x, y] = 0;

                        else if (smerGradijenta[x, y] == Math.PI / 2 && (magnitudaGradijenta[x, y] <= magnitudaGradijenta[x, y - 1] || magnitudaGradijenta[x, y + 1] >= magnitudaGradijenta[x, y]))

                            magnitudaGradijenta[x, y] = 0;

                        else if (smerGradijenta[x, y] == Math.PI / 4 && (magnitudaGradijenta[x, y] <= magnitudaGradijenta[x - 1, y + 1] || magnitudaGradijenta[x, y] <= magnitudaGradijenta[x + 1, y - 1]))

                            magnitudaGradijenta[x, y] = 0;

                        else if (smerGradijenta[x, y] == -Math.PI / 4 && (magnitudaGradijenta[x, y] <= magnitudaGradijenta[x - 1, y - 1] || magnitudaGradijenta[x, y] <= magnitudaGradijenta[x + 1, y + 1]))

                            magnitudaGradijenta[x, y] = 0;
                }
            }

            for (var x = 2; x < blurx - 2; x++)
            {
                for (var y = 2; y < blury - 2; y++)
                {
                    if (smerGradijenta[x, y] == 0)
                        if (magnitudaGradijenta[x - 2, y] > magnitudaGradijenta[x, y] || magnitudaGradijenta[x + 2, y] > magnitudaGradijenta[x, y])
                            magnitudaGradijenta[x, y] = 0;
                    if (smerGradijenta[x, y] == Math.PI / 2)
                        if (magnitudaGradijenta[x, y - 2] > magnitudaGradijenta[x, y] || magnitudaGradijenta[x, y + 2] > magnitudaGradijenta[x, y])
                            magnitudaGradijenta[x, y] = 0;
                    if (smerGradijenta[x, y] == Math.PI / 4)
                        if (magnitudaGradijenta[x - 2, y + 2] > magnitudaGradijenta[x, y] || magnitudaGradijenta[x + 2, y - 2] > magnitudaGradijenta[x, y])
                            magnitudaGradijenta[x, y] = 0;
                    if (smerGradijenta[x, y] == -Math.PI / 4)
                        if (magnitudaGradijenta[x + 2, y + 2] > magnitudaGradijenta[x, y] || magnitudaGradijenta[x - 2, y - 2] > magnitudaGradijenta[x, y])
                            magnitudaGradijenta[x, y] = 0;
                }
            }

            for (var x = 0; x < blurx; x++)
            {
                for (var y = 0; y < blury; y++)
                {
                    if (magnitudaGradijenta[x, y] > ut)
                        magnitudaGradijenta[x, y] = 1;
                }
            }

            //histerezis pocetak

            let pomH = 0
            let pomStaro = -1
            let prolaz = 0

            let nastavi = true
            while ( nastavi ) {
                prolaz = prolaz + 1;
                pomStaro = pomH;
                for (int x = 1; x < width - 1; x++) {
                    for (int y = 1; y < xIzvody - 1; y++) {
                        if (magnitudaGradijenta[x, y] <= ut && magnitudaGradijenta[x, y] >= lt)
                        {
                            double pom1 = magnitudaGradijenta[x - 1, y - 1];
                            double pom2 = magnitudaGradijenta[x, y - 1];
                            double pom3 = magnitudaGradijenta[x + 1, y - 1];
                            double pom4 = magnitudaGradijenta[x - 1, y];
                            double pom5 = magnitudaGradijenta[x + 1, y];
                            double pom6 = magnitudaGradijenta[x - 1, y + 1];
                            double pom7 = magnitudaGradijenta[x, y + 1];
                            double pom8 = magnitudaGradijenta[x + 1, y + 1];

                            if (pom1 == 1 || pom2 == 1 || pom3 == 1 || pom4 == 1 || pom5 == 1 || pom6 == 1 || pom7 == 1 || pom8 == 1)
                            {
                                magnitudaGradijenta[x, y] = 1;
                                pomH = pomH + 1;
                            }

                        }
                    }
                }
                
                if (_maxPrecision)
                {
                    nastavi = pomH != pomStaro;
                }
                else
                {
                    nastavi = prolaz <= precision;
                }
            }

            for (int i = 0; i < xIzvodx; i++)
            {
                for (int j = 0; j < xIzvody; j++)
                {
                    if (magnitudaGradijenta[i, j] <= ut)
                        magnitudaGradijenta[i, j] = 0;
                }
            }

            //histerezis kraj


            return magnitudaGradijenta;
        }

        private void OdrediPragove(int dimx, int dimy)
        {
            //automatsko odredjivanje
            double suma = 0;
            double broj = 0;
            
            for (var x = 1; x < dimx - 1; x++)
                for (var y = 1; y < dimy - 1; y++)
                {
                    if (magnitudaGradijenta[x, y] != 0)
                    {
                        suma += magnitudaGradijenta[x, y];
                        broj++;
                    }
                }
            ut = suma / broj;
            lt = 0.4 * ut;
            
        }

        private double maxi(double[,] mat)
        {
            double m = -1;

            foreach (var el in mat)
            {
                m = el > m ? el : m;
            }

            return m;
        }


        internal void CleanUp()
        {
            xIzvod = null;
            yIzvod = null;
            magnitudaGradijenta = null;
            smerGradijenta = null;
            GC.Collect();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator
{
    internal class Data
    {
        static double[,] x=new double[5,3];
        static char[] c=new char[5] {'@','@','@','@','@' };

        public static void ChangeX(double n1, double n2, double w, char newC)
        {

            if (newC != ' ')
            {
                for (int i = 4; i >= 1; i--)
                {
                    x[i, 0] = x[i - 1, 0];
                    x[i, 1] = x[i - 1, 1];
                    x[i, 2] = x[i - 1, 2];
                    c[i] = c[i - 1];
                }

                x[0, 0] = n1;
                x[0, 1] = n2;
                x[0, 2] = w;
                c[0] = newC;
            }
        }

        public double[,] getX()
        {
            return x;
        }

        public char[] getChar()
        {
            return c;
        }
    }
}

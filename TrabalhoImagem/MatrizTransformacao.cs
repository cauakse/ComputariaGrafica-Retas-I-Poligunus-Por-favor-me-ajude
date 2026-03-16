using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoImagem
{
    internal class MatrizTransformacao
    {

        public class Matriz
        {
            public double[,] M = new double[3, 3];

            public Matriz(double[,] values)
            {
                M = values;
            }

            public static Matriz Multiply(Matriz a, Matriz b)
            {
                double[,] r = new double[3, 3];

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        for (int k = 0; k < 3; k++)
                            r[i, j] += a.M[i, k] * b.M[k, j];

                return new Matriz(r);
            }
        }

        public static Matriz Translation(double tx, double ty)
        {
            return new Matriz(new double[,] {
                {1,0,tx},
                {0,1,ty},
                {0,0,1}
            });
        }

        public static Matriz Scale(double sx, double sy)
        {
            return new Matriz(new double[,] {
                {sx,0,0},
                {0,sy,0},
                {0,0,1}
            });
        }

        public static Matriz Rotation(double angle)
        {
            double rad = angle * Math.PI / 180.0;

            return new Matriz(new double[,] {
                {Math.Cos(rad), -Math.Sin(rad),0},
                {Math.Sin(rad), Math.Cos(rad),0},
                {0,0,1}
            });
        }

        public static Matriz CisalhamentoY (double b)
        {
            return new Matriz(new double[,] {
                {1,b,0},
                {0,1,0},
                {0,0,1}
            });
        }

        public static Matriz CisalhamentoX (double a)
        {
            return new Matriz(new double[,] {
                {1,0,0},
                {a,1,0},
                {0,0,1}
            });
        }

        public static Matriz ReflectionX()
        {
            return new Matriz(new double[,] {
                {1,0,0},
                {0,-1,0},
                {0,0,1}
            });
        }

        public static Matriz ReflectionY()
        {
            return new Matriz(new double[,] {
                {-1,0,0},
                {0,1,0},
                {0,0,1}
            });
        }
    }
    
}

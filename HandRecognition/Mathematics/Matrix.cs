using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    public class Matrix
    {
        public double[,] TheMatrix { get; set; }
        public int Lines { get; set; }
        public int Columns { get; set; }
        

        public Matrix(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            TheMatrix = new double[Lines, Columns];
        }

        public void GenerateRandomValuesBetween(double a, double b)
        {
            Random rand = new Random();
            for (int i = 0; i < Lines; i++)
                for (int j = 0; j < Lines; j++)
                    TheMatrix[i, j] = rand.NextDouble() * (b - a) + a;
        }

        public static Matrix operator* (Matrix a, Matrix b)
        {
            Matrix temp = new Matrix(a.Lines, b.Columns);

            for(int i = 0; i < temp.Lines; i ++)
                for(int j = 0; j < temp.Columns; j ++)
                {
                    double sum = 0;
                    for(int k = 0; k < a.Columns; k ++)
                    {
                        sum += a.TheMatrix[i, k] * a.TheMatrix[k, j];
                    }
                    temp.TheMatrix[i, j] = sum;
                }
            return temp;
        }
    }
}

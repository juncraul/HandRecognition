using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    public class Matrix
    {
        public double[,] theMatrix { get; set; }
        public int Lines { get; set; }
        public int Columns { get; set; }
        

        public Matrix(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            theMatrix = new double[Lines, Columns];
        }

        public void GenerateRandomValuesBetween(double a, double b)
        {
            Random rand = new Random();
            for (int i = 0; i < Lines; i++)
                for (int j = 0; j < Lines; j++)
                    theMatrix[i, j] = rand.NextDouble() * (b - a) + a;
        }
    }
}

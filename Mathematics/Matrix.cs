﻿using System;

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
            var rand = new Random(0);
            for (var i = 0; i < Lines; i++)
                for (var j = 0; j < Columns; j++)
                    TheMatrix[i, j] = rand.NextDouble() * (b - a) + a;
        }

        public Matrix Transpose()
        {
            var temp = new Matrix(Columns, Lines);

            for (var i = 0; i < temp.Lines; i++)
                for (var j = 0; j < temp.Columns; j++)
                    temp.TheMatrix[i, j] = TheMatrix[j, i];

            return temp;
        }

        public int GetMaxValueIndex()
        {
            double max = -10000;
            var maxi = -1;
            var maxj = -1;
            for (var i = 0; i < Lines; i++)
                for (var j = 0; j < Columns; j++)
                    if (TheMatrix[i, j] > max)
                    {
                        max = TheMatrix[i, j];
                        maxi = i;
                        maxj = j;
                    }

            return maxi;
        }

        public void AddToLine(Matrix m, int line)
        {
            for (var i = 0; i < m.Columns; i++)
            {
                TheMatrix[line, i] += m.TheMatrix[0, i];
            }
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Lines)
                throw new Exception();

            var temp = new Matrix(a.Lines, b.Columns);

            for (var i = 0; i < temp.Lines; i++)
                for (var j = 0; j < temp.Columns; j++)
                {
                    double sum = 0;
                    for (var k = 0; k < a.Columns; k++)
                    {
                        sum += a.TheMatrix[i, k] * b.TheMatrix[k, j];
                    }

                    temp.TheMatrix[i, j] = sum;
                }

            return temp;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            var temp = new Matrix(a.Lines, a.Columns);

            for (var i = 0; i < a.Lines; i++)
                for (var j = 0; j < a.Columns; j++)
                    temp.TheMatrix[i, j] = a.TheMatrix[i, j] - b.TheMatrix[i, j];

            return temp;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            var temp = new Matrix(a.Lines, a.Columns);

            for (var i = 0; i < a.Lines; i++)
                for (var j = 0; j < a.Columns; j++)
                    temp.TheMatrix[i, j] = a.TheMatrix[i, j] + b.TheMatrix[i, j];

            return temp;
        }

        public static Matrix operator +(Matrix a, double b)
        {
            var temp = new Matrix(a.Lines, a.Columns);

            for (var i = 0; i < a.Lines; i++)
                for (var j = 0; j < a.Columns; j++)
                    temp.TheMatrix[i, j] = a.TheMatrix[i, j] + b;

            return temp;
        }

        public static Matrix operator -(Matrix a, double b)
        {
            var temp = new Matrix(a.Lines, a.Columns);

            for (var i = 0; i < a.Lines; i++)
                for (var j = 0; j < a.Columns; j++)
                    temp.TheMatrix[i, j] = a.TheMatrix[i, j] - b;

            return temp;
        }

        public static Matrix operator *(Matrix a, double b)
        {
            var temp = new Matrix(a.Lines, a.Columns);

            for (var i = 0; i < a.Lines; i++)
                for (var j = 0; j < a.Columns; j++)
                    temp.TheMatrix[i, j] = a.TheMatrix[i, j] * b;

            return temp;
        }

        public static Matrix operator *(double a, Matrix b)
        {
            return b * a;
        }

        public static Matrix operator +(double a, Matrix b)
        {
            return b + a;
        }

        public static Matrix operator -(double a, Matrix b)
        {
            return b * (-1) + a;
        }

        public double Max(out int maxi, out int maxj)
        {
            double max = -10000;
            maxi = -1;
            maxj = -1;
            for (var i = 0; i < Lines; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (TheMatrix[i, j] > max)
                    {
                        max = TheMatrix[i, j];
                        maxi = i;
                        maxj = j;
                    }
                }
            }

            return TheMatrix[maxi, maxj];
        }

        public double Min(out int mini, out int minj)
        {
            double min = 10000;
            mini = -1;
            minj = -1;
            for (var i = 0; i < Lines; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (TheMatrix[i, j] < min)
                    {
                        min = TheMatrix[i, j];
                        mini = i;
                        minj = j;
                    }
                }
            }

            return TheMatrix[mini, minj];
        }

        public override string ToString()
        {
            var s = "";
            double min;
            double max;
            int mini;
            int minj;
            int maxi;
            int maxj;
            for (var i = 0; i < Lines; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    s += TheMatrix[i, j] + " ";
                }

                s += Environment.NewLine;
            }

            s += Environment.NewLine;

            max = Max(out maxi, out maxj);
            min = Min(out mini, out minj);

            s += "Max: " + max + " at: [" + maxi + ", " + maxj + "]" + Environment.NewLine;
            s += "Min: " + min + " at: [" + mini + ", " + minj + "]" + Environment.NewLine;

            return s;
        }
    }
}
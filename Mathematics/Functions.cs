using System;

namespace Mathematics
{
    public static class Functions
    {
        public static double Sigmoid(double x)
        {
            return Math.Pow(1 + Math.Pow(Math.E, -x), -1);
        }
    }
}
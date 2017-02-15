using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mathematics.Test
{
    [TestClass]
    public class Matrix_Test
    {
        [TestMethod]
        public void MatrixMultiplication_Test()
        {
            Matrix a = new Matrix(2, 3);
            Matrix b = new Matrix(3, 2);

            a.TheMatrix[0, 0] = 1;
            a.TheMatrix[0, 1] = 2;
            a.TheMatrix[0, 2] = 3;
            a.TheMatrix[1, 0] = 4;
            a.TheMatrix[1, 1] = 5;
            a.TheMatrix[1, 2] = 6;

            b.TheMatrix[0, 0] = 7;
            b.TheMatrix[0, 1] = 8;
            b.TheMatrix[1, 0] = 9;
            b.TheMatrix[1, 1] = 10;
            b.TheMatrix[2, 0] = 11;
            b.TheMatrix[2, 1] = 12;

            Matrix c = a * b;

            Assert.AreEqual(c.TheMatrix[0, 0], 58);
            Assert.AreEqual(c.TheMatrix[0, 1], 64);
            Assert.AreEqual(c.TheMatrix[1, 0], 139);
            Assert.AreEqual(c.TheMatrix[1, 1], 154);
        }

        [TestMethod]
        public void MatrixAddition_Test()
        {
            Matrix a = new Matrix(2, 2);
            Matrix b = new Matrix(2, 2);

            a.TheMatrix[0, 0] = 1;
            a.TheMatrix[0, 1] = 2;
            a.TheMatrix[1, 0] = 3;
            a.TheMatrix[1, 1] = 4;

            b.TheMatrix[0, 0] = 5;
            b.TheMatrix[0, 1] = 6;
            b.TheMatrix[1, 0] = 7;
            b.TheMatrix[1, 1] = 8;

            Matrix c = a + b;

            Assert.AreEqual(c.TheMatrix[0, 0], 6);
            Assert.AreEqual(c.TheMatrix[0, 1], 8);
            Assert.AreEqual(c.TheMatrix[1, 0], 10);
            Assert.AreEqual(c.TheMatrix[1, 1], 12);
        }


        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(3, 3);
        }
    }
}

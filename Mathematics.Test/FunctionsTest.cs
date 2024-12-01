using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mathematics.Test
{
    [TestClass]
    public class FunctionsTest
    {
        [TestMethod]
        public void Sigmoid_Test()
        {
            for (double x = -10; x < 10; x ++)
            {
                var result = Functions.Sigmoid(x);

                Assert.IsTrue(result > -1 && result < 1);
            }
        }
    }
}

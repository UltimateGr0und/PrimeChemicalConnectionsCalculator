using PrimeChemicalConnectionsCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChemicalConnectionsCalculatorTests
{
    [TestClass]
    public sealed class FindLCMTests
    {
        [TestMethod]
        public void FindLCMTest_ComonScenerio_CorrectResults()
        {
            int res1 = LCM.FindLCM(4, 5);
            int res2 = LCM.FindLCM(4, 8);
            int res3 = LCM.FindLCM(10, 15);
            int res4 = LCM.FindLCM(17, 17);

            Assert.AreEqual(20, res1);
            Assert.AreEqual(8, res2);
            Assert.AreEqual(30, res3);
            Assert.AreEqual(17, res4);
        }

        [TestMethod]
        public void FindLCMTest_UnusualInputs_ThrowsExceptionsOrBasicResults()
        {
            Assert.AreEqual(LCM.FindLCM(1, 20), 20);
            Assert.AreEqual(LCM.FindLCM(-10, 20), 20);
            Assert.ThrowsException<ArgumentException>(() => LCM.FindLCM(0, 5));

        }
    }
}

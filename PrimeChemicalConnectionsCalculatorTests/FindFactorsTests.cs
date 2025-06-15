using PrimeChemicalConnectionsClaculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChemicalConnectionsCalculatorTests
{
    [TestClass]
    public sealed class FindFactorsTests
    {
        [TestMethod]
        public void FindFactors_FactorsOfNumbersGreaterThanTwo_CorrectFactors()
        {
            var res6 = LCM.findFactors(6);
            var expexted6 = new List<int> { 2, 3 };

            var res3 = LCM.findFactors(3);
            var expexted3 = new List<int> { 3 };

            var res9 = LCM.findFactors(9);
            var expexted9 = new List<int> { 3, 3 };


            Assert.IsTrue(Enumerable.SequenceEqual(res6, expexted6));
            Assert.IsTrue(Enumerable.SequenceEqual(res3, expexted3));
            Assert.IsTrue(Enumerable.SequenceEqual(res9, expexted9));
        }
        [TestMethod]
        public void FindFactors_FactorsOfNumbersLessThanTwo_ThrowException()
        {
            Assert.ThrowsException<ArgumentException>(() => LCM.findFactors(1));
        }
    }
}

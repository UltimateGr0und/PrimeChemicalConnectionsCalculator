using PrimeChemicalConnectionsClaculator;

namespace PrimeChemicalConnectionsCalculatorTests
{
    [TestClass]
    public sealed class ChemicalElementTests
    {
        [TestMethod]
        public void ChemicalElementPeriodTest()
        {
            ChemicalElement e1 = new ChemicalElement(number: 1, formula: "H", name: "_", mass: 100, electronegativity: 1);
            ChemicalElement e2 = new ChemicalElement(number: 25, formula: "Mn", name: "_", mass: 100, electronegativity: 1);
            ChemicalElement e3 = new ChemicalElement(number: 55, formula: "Cs", name: "_", mass: 100, electronegativity: 1);
            ChemicalElement e4 = new ChemicalElement(number: 64, formula: "Gd", name: "_", mass: 100, electronegativity: 1);
            ChemicalElement e5 = new ChemicalElement(number: 118, formula: "Og", name: "_", mass: 1000, electronegativity: 1);
            ChemicalElement e6 = new ChemicalElement(number: 2, formula: "He", name: "_", mass: 100, electronegativity: 1);

            Assert.AreEqual<uint>(e1.Period, 1);
            Assert.AreEqual<uint>(e2.Period, 4);
            Assert.AreEqual<uint>(e3.Period, 6);
            Assert.AreEqual<uint>(e4.Period, 6);
            Assert.AreEqual<uint>(e5.Period, 7);
            Assert.AreEqual<uint>(e6.Period, 1);

        }
        [TestMethod]
        public void ChemicalElementGroupTest()
        {
            var e1 = new ChemicalElement(number: 1, formula: "H", name: "_", mass: 100, electronegativity: 1).Group;
            var e2 = new ChemicalElement(number: 25, formula: "Mn", name: "_", mass: 100, electronegativity: 1).Group;
            var e3 = new ChemicalElement(number: 55, formula: "Cs", name: "_", mass: 100, electronegativity: 1).Group;
            var e4 = new ChemicalElement(number: 64, formula: "Gd", name: "_", mass: 100, electronegativity: 1).Group;
            var e5 = new ChemicalElement(number: 118, formula: "Og", name: "_", mass: 1000, electronegativity: 1).Group;
            var e6 = new ChemicalElement(number: 2, formula: "He", name: "_", mass: 100, electronegativity: 1).Group;

            Assert.AreEqual<uint>(e1, 1);
            Assert.AreEqual<uint>(e2, 2);
            Assert.AreEqual<uint>(e3, 1);
            Assert.AreEqual<uint>(e4, 2);
            Assert.AreEqual<uint>(e5, 8);
            Assert.AreEqual<uint>(e6, 8);

        }
        [TestMethod]
        public void ChemicalElementConstructorTest()
        {
            Assert.ThrowsException<ArgumentException>(() => new ChemicalElement(
                number: 0, formula: "H", name: "_", mass: 1, electronegativity: 1));
            Assert.ThrowsException<ArgumentException>(() => new ChemicalElement(
                number: 10, formula: "H", name: "_", mass: 20, electronegativity: -1));
            Assert.ThrowsException<ArgumentException>(() => new ChemicalElement(
                number: 10, formula: "H", name: "_", mass: 1, electronegativity: 1));
            try
            {
                new ChemicalElement(number: 1, formula: "H", name: "_", mass: 1, electronegativity: 1);
            }
            catch (Exception)
            {
                Assert.Fail();                
            }
        }
    }
}

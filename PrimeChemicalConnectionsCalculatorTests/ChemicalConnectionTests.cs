using PrimeChemicalConnectionsClaculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChemicalConnectionsCalculatorTests
{
    [TestClass]
    public sealed class ChemicalConnectionTests
    {
        [TestMethod]
        public void ConstructorMultipliersTest()
        {
            ChemicalElement e1 = new ChemicalElement(number: 1, formula: "H", name: "_", mass: 100, electronegativity: 2.2f);
            ChemicalElement e2 = new ChemicalElement(number: 25, formula: "Mn", name: "_", mass: 100, electronegativity: 1.55f);
            ChemicalElement e3 = new ChemicalElement(number: 55, formula: "Cs", name: "_", mass: 100, electronegativity: 0.79f);
            ChemicalElement e4 = new ChemicalElement(number: 64, formula: "Gd", name: "_", mass: 100, electronegativity: 1.2f);
            ChemicalElement e5 = new ChemicalElement(number: 118, formula: "Og", name: "_", mass: 1000, electronegativity: null);
            ChemicalElement e6 = new ChemicalElement(number: 2, formula: "He", name: "_", mass: 100, electronegativity: null);

            ChemicalConnection c1 = new ChemicalConnection(e1, e2);
            ChemicalConnection c2 = new ChemicalConnection(e1, e3);
            ChemicalConnection c3 = new ChemicalConnection(e4, e2);

            Assert.AreEqual(c1.Formula, "MnH2");
            Assert.AreEqual(c2.Formula, "CsH");
            Assert.AreEqual(c3.Formula, "Gd3Mn");

            Assert.ThrowsException<ArgumentException>(() => new ChemicalConnection(e2, e2));
            Assert.ThrowsException<ArgumentException>(() => new ChemicalConnection(e2, e6));
        }
        [TestMethod]
        public void NamingTest()
        {
            ChemicalElement e1 = new ChemicalElement(number: 1, formula: "H", name: "hydrogen", mass: 100, electronegativity: 2.2f);
            ChemicalElement e2 = new ChemicalElement(number: 25, formula: "Mn", name: "manganese", mass: 100, electronegativity: 1.55f);
            ChemicalElement e3 = new ChemicalElement(number: 55, formula: "Cs", name: "caesium", mass: 100, electronegativity: 0.79f);
            ChemicalElement e4 = new ChemicalElement(number: 64, formula: "Gd", name: "gadolinium", mass: 100, electronegativity: 1.2f);

            ChemicalConnection c1 = new ChemicalConnection(e1, e2);
            ChemicalConnection c2 = new ChemicalConnection(e1, e3);
            ChemicalConnection c3 = new ChemicalConnection(e4, e2);

            Assert.AreEqual(c1.Name, "manganese dihydrogen");
            Assert.AreEqual(c2.Name, "caesium hydrogen");
            Assert.AreEqual(c3.Name, "trigadolinium manganese");
        }
    }
}

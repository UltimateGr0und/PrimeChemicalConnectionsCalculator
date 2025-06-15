using PrimeChemicalConnectionsCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemicalConnectionsDB.Models
{
    public class ChemicalElementModel : ChemicalElement
    {
        public int ChemicalElementModelId { get; set; }
        ChemicalElementModel(int id, uint number, uint mass, string formula = "", string name = "", float? electronegativity = null)
            : base(number: number, mass: mass, formula: formula, name: name, electronegativity: electronegativity)
        {
            ChemicalElementModelId = id;
        }
    }
}

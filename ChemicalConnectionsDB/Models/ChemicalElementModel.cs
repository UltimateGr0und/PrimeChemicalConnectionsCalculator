using Microsoft.EntityFrameworkCore;
using PrimeChemicalConnectionsCalculator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemicalConnectionsDB.Models
{
    [PrimaryKey(nameof(Number))]
    public class ChemicalElementModel : ChemicalElement
    {
        public ChemicalElementModel(uint number, uint mass, string formula = "", string name = "", float? electronegativity = null)
            : base(number: number, mass: mass, formula: formula, name: name, electronegativity: electronegativity)
        {
            
        }
    }
}

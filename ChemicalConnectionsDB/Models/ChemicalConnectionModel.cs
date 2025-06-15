using PrimeChemicalConnectionsCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemicalConnectionsDB.Models
{  
    public class ChemicalConnectionModel : ChemicalConnection
    {
        public int ChemicalConnectionModelId { get; set; }
        ChemicalConnectionModel(int id, ChemicalElementModel first, ChemicalElementModel second)
            : base(first: first, second: second)
        {
            ChemicalConnectionModelId = id;
        }
    }
}

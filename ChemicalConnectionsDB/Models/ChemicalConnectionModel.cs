using Microsoft.EntityFrameworkCore;
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
        public int Id { get; set; }
        public ChemicalConnectionModel(int id, ChemicalElementModel first, ChemicalElementModel second)
            : base(first: first, second: second)
        {
            Id = id;
        }
        
        private ChemicalConnectionModel():base() { }
    }
}

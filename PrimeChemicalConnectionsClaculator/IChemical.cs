using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChemicalConnectionsClaculator
{
    internal interface IChemical
    {
        public string Name { get; }
        public string Formula { get; }
        public uint Mass { get; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChemicalConnectionsClaculator
{
    public class ChemicalElement : IChemical
    {
        private uint _number;
        private string _formula;
        private string _name;
        private uint _mass;
        private int _charge;

        public uint Number
        {
            get { return _number; }
        }
        public string Formula
        {
            get { return _formula; }
        }

        public string Name
        {
            get { return _name; }
        }

        public uint Mass
        {
            get { return _mass; }
        }

        public int Charge
        {
            get { return _charge; }
        }

        public ChemicalElement(uint number, string formula, string name, uint mass, int charge)
        {
            if (mass > 0)
            {
                this._number = number;
            }
            else
            {
                throw new ArgumentException("Atomic number cannot be zero or less");
            }
            this._formula = formula;
            this._name = name;
            if (mass > 0)
            {
                this._mass = mass;
            }
            else
            {
                throw new ArgumentException("mass cannot be zero or less");
            }

            if (charge >= -3 && charge <= 4)
            {
                this._charge = charge;
            }
            else
            {
                throw new ArgumentException("charge must be in interval between -3 and 4");
            }

        }
    }

}

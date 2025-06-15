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
        private float _electronegativity;
        private uint groupPos()
        {
            uint[] sizes = { 2, 8, 8, 18, 18, 32, 32 };
            uint res = _number;
            for (uint i = 0; i < Period-1; i++)
            {
                res -= sizes[i];
            }
            return res;
        }
        public uint Number
        {
            get { return _number; } set { _number = value; }
        }
        public string Formula
        {
            get { return _formula; } set { _formula = value; }
        }
        public string Name
        {
            get { return _name; } set { _name = value; }
        }
        public uint Mass
        {
            get { return _mass; }
        }
        public float Electronegativity
        {
            get; set;
        }

        public uint Period
        {
            get
            {
                if (_number == 0)
                    throw new Exception("atomic number cannot be zero");
                else if (_number >= 1 && _number <= 2)
                    return 1;
                else if (_number >= 3 && _number <= 10)
                    return 2;
                else if (_number >= 11 && _number <= 18)
                    return 3;
                else if (_number >= 19 && _number <= 36)
                    return 4;
                else if (_number >= 37 && _number <= 54)
                    return 5;
                else if (_number >= 55 && _number <= 86)
                    return 6;
                else if (_number >= 87 && _number <= 118)
                    return 7;
                else
                    throw new Exception("unknown period");
            }
        }
        public uint Group
        {
            get
            {
                if (Period == 1)
                {
                    if (_number == 1)
                        return 1;
                    else return 8;
                }
                else if (Period == 2|| Period ==3 )
                    return _number-2-(Period-2)*8;
                else if (Period == 4 || Period == 5)
                {
                    uint pos = groupPos();
                    if (pos == 1)
                    {
                        return 1;
                    }else if (pos <=12)
                    {
                        return 2;
                    }
                    else
                    {
                        return pos - 10;
                    }
                }
                else if (Period == 6 || Period == 7)
                {
                    uint pos = groupPos();
                    if (pos == 1)
                    {
                        return 1;
                    }
                    else if (pos <= 27)
                    {
                        return 2;
                    }
                    else
                    {
                        return pos - 24;
                    }
                }
                throw new Exception("unknown group");
            }
        }

        public ChemicalElement(uint number, string formula, string name, uint mass, float electronegativity)
        {
            if (number > 0)
            {
                _number = number;
            }
            else
            {
                throw new ArgumentException("Atomic number cannot be zero or less");
            }
            _formula = formula;
            _name = name;
            if (mass >= _number)
            {
                _mass = mass;
            }
            else
            {
                throw new ArgumentException("mass cannot be less than Atomic number");
            }
            if (electronegativity>0.0f && electronegativity<5.0f)
            {
                _electronegativity = electronegativity;
            }
            else
            {
                throw new ArgumentException("Electronegativity must be between 0 and 5");
            }

        }
    }

}

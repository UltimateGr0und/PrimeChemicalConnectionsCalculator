using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrimeChemicalConnectionsClaculator
{
    public class ChemicalConnection : IChemical
    {
        private readonly Dictionary<uint, string> Prefixes = new Dictionary<uint, string> { 
            { 1, "" },
            { 2, "di" },
            { 3, "tri" },
            { 4, "tetra" },
            { 5, "penta" },
            { 6, "hex" },
            { 7, "septa" },
            { 8, "okta" },
            { 9, "nona" },
        }; 
        private ChemicalElement _kation;
        private uint _kationMultiplier;
        private ChemicalElement _anion;
        private uint _anionMultiplier;

        public string Name
        {
            get
            {
                return (_kationMultiplier > 9 ? _kationMultiplier : Prefixes[_kationMultiplier])
                    + _kation.Name
                    + " "
                    + (_anionMultiplier > 9 ? _anionMultiplier : Prefixes[_anionMultiplier])
                    + _anion.Name;
            }
        }
        public string Formula
        {
            get
            {
                return _kation.Formula
                    + (_kationMultiplier != 1 ? _kationMultiplier : "")
                    + _anion.Formula
                    + (_anionMultiplier != 1 ? _anionMultiplier : "");
            }
        }
        public uint Mass
        {
            get
            {
                return _kation.Mass * _kationMultiplier + _anion.Mass * _anionMultiplier;
            }
        }
        public ChemicalConnection(ChemicalElement first, ChemicalElement second)
        {
            if (first.Number == second.Number) throw new ArgumentException("No connection between same elements");

            if (first.Electronegativity==null || second.Electronegativity==null)
            {
                throw new ArgumentException("No connection between elements without electronegativity");
            }

            if(first.Electronegativity > second.Electronegativity)
            {
                _anion = first;
                _kation = second;
            }
            else
            {
                _anion = second;
                _kation = first;
            }
            int chargeAnion = Convert.ToInt32(_anion.Group)-8;
            if (_anion.Period == 1)
            {
                chargeAnion += 6;
            }
            
            int chargeKation = Convert.ToInt32(_kation.Group);

            if (chargeKation == 0 || chargeAnion == 0) 
            {
                throw new ArgumentException("Connection cannot be done");
            }

            int lcm = LCM.FindLCM(chargeAnion, chargeKation);

            _anionMultiplier = Convert.ToUInt32(Math.Abs(lcm / chargeAnion));
            _kationMultiplier = Convert.ToUInt32(Math.Abs(lcm / chargeKation));

        }


    }
}

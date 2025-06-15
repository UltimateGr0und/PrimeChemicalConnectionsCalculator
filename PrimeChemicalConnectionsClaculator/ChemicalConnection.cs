using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrimeChemicalConnectionsCalculator
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
        private ChemicalElement _first;
        private uint _kationMultiplier;
        private ChemicalElement _second;
        private uint _anionMultiplier;
        private bool _isFirstKation;

        private void RecountIsFirstKation()
        {
            if (_first.Electronegativity > _second.Electronegativity)
            {
                _isFirstKation = false;
            }
            else
            {
                _isFirstKation = true;
            }
        }
        private void RecountMultipiers()
        {
            int chargeAnion = Convert.ToInt32(Anion.Group) - 8;
            if (Anion.Period == 1)
            {
                chargeAnion += 6;
            }

            int chargeKation = Convert.ToInt32(Kation.Group);

            if (chargeKation == 0 || chargeAnion == 0)
            {
                throw new ArgumentException("Connection cannot be done");
            }

            int lcm = LCM.FindLCM(chargeAnion, chargeKation);

            _anionMultiplier = Convert.ToUInt32(Math.Abs(lcm / chargeAnion));
            _kationMultiplier = Convert.ToUInt32(Math.Abs(lcm / chargeKation));
        }

        public ChemicalElement First
        {
            get { return _first; }
            set
            {
                if (value.Electronegativity == null)
                {
                    throw new ArgumentException("No connection between elements without electronegativity");
                }
                if (value.Number == _second.Number)
                {
                    throw new ArgumentException("No connection between same elements");
                }
                _first = value;

                RecountIsFirstKation();
                RecountMultipiers();
            }
        }

        public ChemicalElement Second
        {
            get { return _second; }
            set
            {
                if (value.Electronegativity == null)
                {
                    throw new ArgumentException("No connection between elements without electronegativity");
                }
                if (value.Number == _first.Number)
                {
                    throw new ArgumentException("No connection between same elements");
                }
                _second = value;

                RecountIsFirstKation();
                RecountMultipiers();
            }
        }



        public string Name
        {
            get
            {
                return (_kationMultiplier > 9 ? _kationMultiplier : Prefixes[_kationMultiplier])
                    + Kation.Name
                    + " "
                    + (_anionMultiplier > 9 ? _anionMultiplier : Prefixes[_anionMultiplier])
                    + Anion.Name;
            }
        }
        public string Formula
        {
            get
            {
                return Kation.Formula
                    + (_kationMultiplier != 1 ? _kationMultiplier : "")
                    + Anion.Formula
                    + (_anionMultiplier != 1 ? _anionMultiplier : "");
            }
        }
        public uint Mass
        {
            get
            {
                return Kation.Mass * _kationMultiplier + Anion.Mass * _anionMultiplier;
            }
        }
        public ChemicalElement Kation
        {
            get{
                if (_isFirstKation)
                {
                    return _first;
                }
                return _second;
            }
        }
        public ChemicalElement Anion
        {
            get
            {
                if (_isFirstKation)
                    return _second;
                return _first;
            }
        }
        public ChemicalConnection(ChemicalElement first, ChemicalElement second)
        {
            if (first.Number == second.Number) throw new ArgumentException("No connection between same elements");

            if (first.Electronegativity==null || second.Electronegativity==null)
            {
                throw new ArgumentException("No connection between elements without electronegativity");
            }
            _first = first;
            _second = second;

            RecountIsFirstKation();
            RecountMultipiers();
        }

        protected ChemicalConnection() { }

    }
}

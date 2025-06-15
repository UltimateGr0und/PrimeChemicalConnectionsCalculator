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
        private ChemicalElement _kation;
        private uint _kationMultiplier;
        private ChemicalElement _anion;
        private uint _anionMultiplier;

        public string Name
        {
            get
            {
                return _kationMultiplier + _kation.Name + _anionMultiplier + _anion.Name;
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

            uint chargeAnion = 8 - _anion.Group;
            uint chargeKation = _kation.Group;



        }


    }
}

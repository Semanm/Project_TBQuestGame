using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint3EZ
{
    // TODO Sprint 3 Mod 01 - add a currency type structure
    public struct CurrencyType
    {

        #region ENUMERABLES, DICTIONARIES

        public enum BaseMaterialType
        {
            Gold,
            Silver,
            Bronze
        }

        public static Dictionary<BaseMaterialType, int> baseMaterialValue = new Dictionary<BaseMaterialType, int>{
            {BaseMaterialType.Gold, 10},
            {BaseMaterialType.Silver, 5},
            {BaseMaterialType.Bronze, 1}
        };

        #endregion

        #region FIELDS

        private string _name;
        private string _descrtiption;
        private BaseMaterialType _baseMaterial;
        private int _quantityOfBaseMaterial;
        private int _value;


        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _descrtiption; }
        }


        public BaseMaterialType BaseMaterial
        {
            get { return _baseMaterial; }
        }

        public int QuantityOfBaseMaterial
        {
            get { return _quantityOfBaseMaterial; }
        }

        public int Value
        {
            get { return _value; }
        }

        #endregion

        #region CONSTRUCTORS

        public CurrencyType(string name, string description, BaseMaterialType baseMaterial, int quantityOfBaseMaterial)
        {
            _name = name;
            _descrtiption = description;
            _baseMaterial = baseMaterial;
            _quantityOfBaseMaterial = quantityOfBaseMaterial;
            
            // calculate value of currency when instatiated
            _value = quantityOfBaseMaterial * baseMaterialValue[baseMaterial];
        }

        #endregion

        #region METHODS



        #endregion
        
    }
}

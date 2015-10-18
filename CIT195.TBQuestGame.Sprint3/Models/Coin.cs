using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint3
{
    //TODO Sprint 3 Mod 03a - add a Coin class
    /// <summary>
    /// class to create new coins
    /// </summary>
    public class Coin
    {
        #region ENUMERABLES



        #endregion

        #region FIELDS

        private string _name;
        private string _description;
        private Treasure.Material _typeOfMaterial;
        private int _quantitiyOfMaterial;

        #endregion

        #region PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Treasure.Material TypeOfMaterial
        {
            get { return _typeOfMaterial; }
            set { _typeOfMaterial = value; }
        }

        public int QuantityOfMaterial
        {
            get { return _quantitiyOfMaterial; }
            set { _quantitiyOfMaterial = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Coin(string name, string description, Treasure.Material typeOfMaterial, int quantityOfMaterial)
        {
            _name = name;
            _description = description;
            _typeOfMaterial = typeOfMaterial;
            _quantitiyOfMaterial = quantityOfMaterial;
        }

        #endregion

        #region METHODS



        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint3EZ
{
    //TODO Sprint 3 Mod 03 - add a Coin class
    /// <summary>
    /// class to create new coins
    /// </summary>
    public class Coin
    {
        #region ENUMERABLES



        #endregion

        #region FIELDS

        private Treasure.Material _typeOfMaterial;
        private int _quantitiyOfMaterial;

        #endregion

        #region PROPERTIES

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

        public Coin(Treasure.Material typeOfMaterial, int quantityOfMaterial)
        {
            _typeOfMaterial = typeOfMaterial;
            _quantitiyOfMaterial = quantityOfMaterial;
        }

        #endregion

        #region METHODS



        #endregion
    }
}

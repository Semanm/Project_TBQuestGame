using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint3
{
    // TODO Sprint 3 Mod 10 - add a treasure class for the player to store all the treasure
    public class Treasure
    {
        #region ENUMERABLES, DICTIONARIES



        #endregion


        #region FIELDS

        // TODO Sprint 3 Mod 11 - add a list of currency
        private List<PlayerCurrency> _currency;

        #endregion

        #region PROPERTIES

        public List<PlayerCurrency> Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        #endregion

        #region CONSTRUCTORS

        // // TODO Sprint 3 Mod 12c - initialize the currency list in the Treasure object
        public Treasure()
        {
            _currency = new List<PlayerCurrency>();
        }

        #endregion

        #region METHODS



        #endregion
    }
}

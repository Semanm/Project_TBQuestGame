using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint3EZ
{
    // TODO Sprint 3 Mod 01a - add a treasure class
    /// <summary>
    /// base class for all treasures
    /// </summary>
    public class Treasure
    {
        #region ENUMERABLES
        // TODO Sprint 3 Mod 01b - add an enum of material types for treasures
        public enum Material
        {
            Gold,
            Silver,
            Bronze,
            Diamond,
            Emerald
        }

        #endregion


        #region FIELDS

        // TODO Sprint 3 Mod 01c - add a dictionary to hold the values of each material
        private Dictionary<Material, int> materialValue = new Dictionary<Material, int>();

        private List<Coin> _coins;

        #endregion

        #region PROPERTIES
        public List<Coin> Coins
        {
            get { return _coins; }
            set { _coins = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Treasure()
        {
            // TODO Sprint 3 Mod 01e - call the initialize material values method
            InitializeMaterialValues();

            _coins = new List<Coin>();

        }

        #endregion

        #region METHODS

        // TODO Sprint 3 Mod 01d - add a method to initialze the material values
        private void InitializeMaterialValues()
        {
            materialValue[Material.Gold] = 10;
            materialValue[Material.Silver] = 5;
            materialValue[Material.Bronze] = 1;
            materialValue[Material.Diamond] = 20;
            materialValue[Material.Emerald] = 15;
        }

        // TODO Sprint 3 Mod 01f - add a method to return a material's value
        public int Value(Material materialType)
        {
            return materialValue[materialType];
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint3EZ
{
    // TODO Sprint 3 Mod 20 - add an Weapon class derived from the GameItem class
    public class Weapon : GameItem
    {
        #region ENUMERABLES, DICTIONARIES

        public enum WeaponType
        {
            knife,
            gun
        }

        #endregion


        #region FIELDS

        private WeaponType _type;

        public WeaponType Type
        {
            get { return _type; }
            set { _type = value; }
        }



        #endregion

        #region PROPERTIES



        #endregion

        #region CONSTRUCTORS

        public Weapon()
        {

        }

        // note constructor inheritance from base class
        public Weapon(
            WeaponType type,
            string name,
            string description)
            : base(name, description)
        {

        }

        #endregion

        #region METHODS



        #endregion
    }
}

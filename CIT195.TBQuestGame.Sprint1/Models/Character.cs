using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint1
{
    /// <summary>
    /// base class for player and guests in game
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum GenderType
        {
            Male,
            Female
        }

        public enum RaceType
        {
            Human,
            Elf,
            Dwarf
        }

        #endregion

        #region FIELDS

        protected string _name;
        protected GenderType _gender;
        protected RaceType _race;
        protected int _currentRoomNumber;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public GenderType Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public int CurrentRoomNumber
        {
            get { return _currentRoomNumber; }
            set { _currentRoomNumber = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        /// <summary>
        /// instantiate a character and set intial properties
        /// </summary>
        /// <param name="name">character name</param>
        /// <param name="gender">character gender</param>
        /// <param name="race">character race</param>
        /// <param name="currentRoomNumber">room location as an index of the hall array</param>
        public Character(
            string name,
            GenderType gender,
            RaceType race,
            int currentRoomNumber)
        {
            _name = name;
            _gender = gender;
            _race = race;
            _currentRoomNumber = currentRoomNumber;
        }

        #endregion

        #region METHODS

        public virtual string Greeting()
        {
            return ("Hello");
        }

        #endregion
    }
}

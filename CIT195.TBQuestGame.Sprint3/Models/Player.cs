using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint3
{
    /// <summary>
    /// Player class, inherites from Character class
    /// </summary>
    public class Player : Character
    {
        #region ENUMERABLES

        public enum ActionChoice
        {
            None,
            QuitGame,
            Move
        }

        #endregion

        #region FIELDS

        private int _lives;
        private bool _inHall;
        private int _actionCount = Enum.GetNames(typeof(ActionChoice)).Length;
        private List<CoinGroup> _coins; // TODO Sprint 3 Mod 07a - add a field/property to hold the player's coins
        private List<Weapon> _weapons; // TODO Sprint 3 Mod 21 - add a field/property to hold the player's weapons      

        #endregion

        #region PROPERTIES
        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public bool InHall
        {
            get { return _inHall; }
            set { _inHall = value; }
        }

        public int ActionCount
        {
            get { return _actionCount; }
        }
        
        public List<CoinGroup> Coins
        {
            get { return _coins; }
            set { _coins = value; }
        }

        public List<Weapon> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// instantiate a player and set intial properties
        /// </summary>
        /// <param name="name">player name</param>
        /// <param name="gender">player gender</param>
        /// <param name="race">player race</param>
        /// <param name="currentRoomNumber">room location as an index of the hall array</param>
        public Player(
            string name,
            GenderType gender,
            RaceType race,
            int currentRoomNumber)
            : base(name, gender, race, currentRoomNumber)
        {
            _lives = 1;

            // TODO Sprint 3 Mod 07b - instantiate the player's coin group list
            _coins = new List<CoinGroup>();

            // TODO Sprint 3 Mod 22 - instantiate the player's weapons list
            _weapons = new List<Weapon>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// override method for a player who leaves the Mansion
        /// </summary>
        /// <returns>message for leaving</returns>
        public override string Leave()
        {
            string leavingMessage;
            leavingMessage = String.Format("Player {0} has left the game. The Mansion Master will decide whether to continue playing the game.", _name);

            return (leavingMessage);
        }

        #endregion
    }
}

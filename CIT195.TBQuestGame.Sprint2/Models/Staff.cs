using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint2
{
    /// <summary>
    /// Guest class, inherites from Character class
    /// </summary>
    public class Staff : Character, IGreeting
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS

        private bool _appearsFriendly;
        private string _initialGreeting;

        #endregion

        #region PROPERTIES

        public bool AppearsFriendly
        {
            get { return _appearsFriendly; }
            set { _appearsFriendly = value; }
        }

        public string InitialGreeting
        {
            get { return _initialGreeting; }
            set { _initialGreeting = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Staff()
        {

        }
        /// <summary>
        /// instantiate a guest and set intial properties
        /// </summary>
        /// <param name="name">guest name</param>
        /// <param name="gender">guest gender</param>
        /// <param name="race">guest race</param>
        /// <param name="currentRoomNumber">room location as an index of the hall array</param>
        public Staff(
            string name,
            GenderType gender,
            RaceType race,
            int currentRoomNumber)
            : base(name, gender, race, currentRoomNumber)
        {

        }

        #endregion

        #region METHODS

        /// <summary>
        /// override method for the staff's greeting
        /// </summary>
        /// <returns>greeting string</returns>
        public string Greeting(Player player)
        {
            string greeting;
            greeting = string.Format("Hello, my name is {1}. {3}", _name, _initialGreeting);

            return greeting;
        }

        /// <summary>
        /// override method for a staff who leaves the Mansion
        /// </summary>
        /// <returns>message for leaving</returns>
        public override string Leave()
        {
            string leavingMessage;
            leavingMessage = String.Format("Staff {0} has left the game. The Mansion Master will decide whether to replace {0}.", _name);

            return (leavingMessage);
        }

        #endregion
    }
}

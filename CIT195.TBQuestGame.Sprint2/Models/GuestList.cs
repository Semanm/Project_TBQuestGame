using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint1
{
    /// <summary>
    /// class to manage an array of guests
    /// </summary>
    public class GuestList
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS

        public const int NUMBER_OF_GUESTS = 2;

        private Guest[] _guests;


        #endregion

        #region PROPERTIES
        public Guest[] Guests
        {
            get { return _guests; }
            set { _guests = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public GuestList()
        {
            _guests = new Guest[NUMBER_OF_GUESTS];
            InitializeGuests();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// instantiate and add the properties of the guests
        /// </summary>
        private void InitializeGuests()
        {
            _guests = new Guest[NUMBER_OF_GUESTS];

            for (int guestNumber = 0; guestNumber < NUMBER_OF_GUESTS; guestNumber++)
            {
                _guests[guestNumber] = new Guest();
            }

            _guests[0].Name = "Mr. Smith";
            _guests[0].Gender = Guest.GenderName.Male;
            _guests[0].Race = Guest.RaceName.Elf;
            _guests[0].AppearsFriendly = true;
            _guests[0].CurrentRoomNumber = 2;
            _guests[0].Greeting = "Hello, my name is Mr. Smith and I am a traveler from the North Region.";

            _guests[1].Name = "Gordle";
            _guests[1].Gender = Guest.GenderName.Female;
            _guests[1].Race = Guest.RaceName.Dwarf;
            _guests[1].AppearsFriendly = false;
            _guests[1].CurrentRoomNumber = 3;
            _guests[1].Greeting = "You are in my room. What are your intentions?";

        }

        #endregion
    }
}

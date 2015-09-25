using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint2
{
    /// <summary>
    /// class to manage the game flow
    /// </summary>
    class GameController
    {
        #region FIELDS

        //
        // declare the major data ojects
        //
        private Player _myPlayer;
        private Hall _hall;
        private GuestList _guestList;
        private StaffList _staffList;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// when the GameController object is instantiated, setup the game and begin playing
        /// </summary>
        public GameController()
        {
            SetupGame();
            PlayGame();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Set up all data objects before game play
        /// </summary>
        private void SetupGame()
        {
            //
            // instantiate a Player, Hall, and Guests
            //
            InitializePlayer();
            InitializeHall();
            InitializeGuestList();
            InitializeStaffList();
        }

        /// <summary>
        /// perform the game loop
        /// </summary>
        private void PlayGame()
        {
            //
            // instantiate a new ConsoleView object
            //
            ConsoleView userConsoleView = new ConsoleView(_myPlayer, _hall, _guestList, _staffList);

            userConsoleView.DisplayWelcomeScreen();

            userConsoleView.DisplayAllObjectInformation();

            userConsoleView.DisplayReset();
            userConsoleView.DisplayExitPrompt();
        }

        /// <summary>
        /// initialize the player wtth their properities
        /// </summary>
        private void InitializePlayer()
        {
            _myPlayer = new Player(
                "Bonzo",
                Player.GenderType.Female,
                Player.RaceType.Human,
                1);
        }

        /// <summary>
        /// initialize the hall and rooms with their properties
        /// </summary>
        private void InitializeHall()
        {
            _hall = new Hall();

            //
            // initialize array of rooms
            //
            for (int roomNumber = 0; roomNumber < 4; roomNumber++)
            {
                _hall.Rooms[roomNumber] = new Room();
            }

            //
            // add room information
            //
            _hall.Rooms[0].Name = "The Great Hall";
            _hall.Rooms[0].Description = "You are in a large room with oak beams and dark wood panel." +
                                    "The room is filled with furniture dating back to the 18th century." +
                                     "On all but one wall you notice a large door large brass knobs.";
            _hall.Rooms[0].Type = Room.TypeName.Room;
            _hall.Rooms[0].IsLighted = true;
            _hall.Rooms[0].CanEnter = true;

            _hall.Rooms[1].Name = "The Master Bedroom";
            _hall.Rooms[1].Description = "You are in a large room with oak beams and dark wood panel.";
            _hall.Rooms[1].Type = Room.TypeName.Room;
            _hall.Rooms[1].IsLighted = false;
            _hall.Rooms[1].CanEnter = true;
            _hall.Rooms[1].RoomGuest = new Guest
            {
                Name = "Mr. Smith",
                Gender = Guest.GenderType.Male,
                Race = Guest.RaceType.Elf,
                AppearsFriendly = true,
                CurrentRoomNumber = 1,
                InitialGreeting = "Hello, my name is Mr. Smith and I am a traveler from the North Region."
            };

            _hall.Rooms[2].Name = "The Kitchen";
            _hall.Rooms[2].Description = "You are in a large room with oak beams and dark wood panel.";
            _hall.Rooms[2].Type = Room.TypeName.Room;
            _hall.Rooms[2].IsLighted = true;
            _hall.Rooms[2].CanEnter = true;
            _hall.Rooms[2].RoomGuest = null;
            _hall.Rooms[2].RoomStaff = new Staff
            {
                Name = "Mrs. Porter",
                Gender = Guest.GenderType.Female,
                Race = Guest.RaceType.Elf,
                AppearsFriendly = true,
                CurrentRoomNumber = 2,
                InitialGreeting = "Hello, my name is Mrs. Porter."
            };

            _hall.Rooms[3].Name = "The Armory";
            _hall.Rooms[3].Description = "You are in a room, crowed with racks of swords.";
            _hall.Rooms[3].Type = Room.TypeName.Room;
            _hall.Rooms[3].IsLighted = true;
            _hall.Rooms[3].CanEnter = true;
            _hall.Rooms[3].RoomGuest = new Guest
            {
                Name = "Gordle",
                Gender = Guest.GenderType.Female,
                Race = Guest.RaceType.Dwarf,
                AppearsFriendly = false,
                CurrentRoomNumber = 3,
                InitialGreeting = "You are in my room. What are your intentions?"
            };
        }

        /// <summary>
        /// initialize the guest list from the room guest information
        /// </summary>
        public void InitializeGuestList()
        {
            _guestList = new GuestList();

            int guestNumber = 0;

            foreach (Room room in _hall.Rooms)
            {
                if (room.RoomGuest != null)
                {
                    _guestList.Guests[guestNumber] = room.RoomGuest;
                    guestNumber++;
                }
            }

        }

        /// <summary>
        /// initialize the staff list from the room staff information
        /// </summary>
        public void InitializeStaffList()
        {
            _staffList = new StaffList();

            int staffNumber = 0;

            foreach (Room room in _hall.Rooms)
            {
                if (room.RoomStaff != null)
                {
                    _staffList.Staff[staffNumber] = room.RoomStaff;
                    staffNumber++;
                }
            }

        }

        #endregion
    }
}

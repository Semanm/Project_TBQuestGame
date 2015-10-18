using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint3
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
        private ConsoleView _userConsoleView;
        private Treasure _treasures; // TODO Sprint 3 Mod 02a - add a game object backing field
        private Player.ActionChoice _playerActionChoice;

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
            InitializeHall();
            InitializeGuestList();
            InitializeStaffList();
            InitializeTreasures();         // TODO Sprint 3 Mod 02c - call the method to initialze the game treasure types
            InitializePlayer();
            InitializeUserConsoleView();
        }

        /// <summary>
        /// perform the game loop
        /// </summary>
        private void PlayGame()
        {

            _userConsoleView.DisplayWelcomeScreen();

            _userConsoleView.DisplayAllObjectInformation();

            //
            // game loop
            //
            while (true)
            {
                if (_myPlayer.InHall)
                {
                    _userConsoleView.DisplayHallMessage();
                }
                else
                {
                    _userConsoleView.DisplayRoomMessage();
                }

                _playerActionChoice = _userConsoleView.GetPlayerAction();

                ImplementPlayerAction(_playerActionChoice);

            }

            _userConsoleView.DisplayReset();
            _userConsoleView.DisplayExitPrompt();
        }

        /// <summary>
        /// process the user's action choice
        /// </summary>
        /// <param name="playerActionChoice">playerActionChoice</param>
        private void ImplementPlayerAction(Player.ActionChoice playerActionChoice)
        {
            switch (playerActionChoice)
            {
                case Player.ActionChoice.None:
                    throw new System.ArgumentException("None is and invalid ActionChoice", "");
                case Player.ActionChoice.QuitGame:
                    _userConsoleView.DisplayExitPrompt();
                    break;
                case Player.ActionChoice.Move:
                    // player moves to hall
                    if (!_myPlayer.InHall)
                    {
                        _myPlayer.InHall = true;

                        _userConsoleView.DisplayHallMessage();
                    }
                    // player chooses room
                    else
                    {
                        int newRoomNumber = _userConsoleView.GetPlayerRoomNumberChoice();

                        _myPlayer.CurrentRoomNumber = newRoomNumber;
                        _myPlayer.InHall = false;
                    }
                    break;
                default:
                    throw new System.ArgumentException("This ActionChoice has not been implemnted in the switch.", "");
                    break;
            }
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

            _myPlayer.InHall = true;

            // TODO Sprint 3 Mod 09 - give the player some coins at the start of the game
            // TOOD Sprint 3 Mod 09! - handle magic numbers
            // give the player some money at the start of the game
            CoinGroup smallGoldCoins = new CoinGroup()
            {
                Quantity = 2,
                CoinType = _treasures.CoinTypes[0]
            };
            CoinGroup smallSilverCoins = new CoinGroup()
            {
                Quantity = 10,
                CoinType = _treasures.CoinTypes[1]
            };
            CoinGroup smallBronzeCoins = new CoinGroup()
            {
                Quantity = 20,
                CoinType = _treasures.CoinTypes[2]
            };

            _myPlayer.Coins.Add(smallGoldCoins);
            _myPlayer.Coins.Add(smallSilverCoins);
            _myPlayer.Coins.Add(smallBronzeCoins);


            // TODO Sprint 3 Mod 23 - give the player some weapons at the beginning of the game
            // give the player some weapons at the beginning of the game
            _myPlayer.Weapons.Add(
                new Weapon
                {
                    Type = Weapon.WeaponType.gun,
                    Name = "Thompson Submachine Gun",
                    Description = "Fast firing submachine gun with a 50 shell mag"
                });

            _myPlayer.Weapons.Add(
                new Weapon
                {
                    Type = Weapon.WeaponType.knife,
                    Name = "Bowie Knife",
                    Description = "Really big knife"
                });
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

        // TODO Sprint 3 Mod 02b - add a method to initialze the game treasure types
        /// <summary>
        /// intitialize the type of treasures in the game
        /// </summary>
        public void InitializeTreasures()
        {
            _treasures = new Treasure();


            // TODO Sprint 3 Mod 06 - initialize the coin types
            Coin goldCoin = new Coin(
                "Small Gold Coin",
                "Gold coin with the Kings's face on one side and the Castle Wilhelm on the other side.",
                Treasure.Material.Gold,
                1);

            Coin silverCoin = new Coin(
                "Samll Silver Coin",
                "Silver coin with the Queen's face on one side and the River Thomes on the other side.",
                Treasure.Material.Silver,
                1);

            Coin bronzeCoin = new Coin(
                "Small Bronze Coin",
                "Bronze coin with the Prince's face on one side and Mount Fidoria on the other side.",
                Treasure.Material.Bronze,
                1);

            _treasures.CoinTypes.Add(goldCoin);
            _treasures.CoinTypes.Add(silverCoin);
            _treasures.CoinTypes.Add(bronzeCoin);
        }

        // TODO Sprint 3 Mod 05c - modify the ConsoleView constructor call to add the list of treasure types
        /// <summary>
        /// initialize the ConsoleView object
        /// </summary>
        public void InitializeUserConsoleView()
        {
            //
            // instantiate a new ConsoleView object
            //
            _userConsoleView = new ConsoleView(_myPlayer, _hall, _guestList, _staffList, _treasures);
        }

        #endregion
    }
}

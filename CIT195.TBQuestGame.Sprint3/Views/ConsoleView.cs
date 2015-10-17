using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint3
{
    public class ConsoleView
    {
        #region FIELDS

        //
        // window size
        //
        private const int WINDOW_WIDTH = ViewSettings.WINDOW_WIDTH;
        private const int WINDOW_HEIGHT = ViewSettings.WINDOW_HEIGHT;

        //
        // horizontal and verical margins in console window for display
        //
        private const int DISPLAY_HORIZONTAL_MARGIN = ViewSettings.DISPLAY_HORIZONTAL_MARGIN;
        private const int DISPALY_VERITCAL_MARGIN = ViewSettings.DISPALY_VERITCAL_MARGIN;

        //
        // declare the major data objects
        //
        private Player _myPlayer;
        private Hall _hall;
        private GuestList _guestList;
        private StaffList _staffList;
        private List<CurrencyType> _gameCurrency; //TODO Sprint 3 Mod 04 - add a gameCurrency backing field for the game currency list to the ConsoleView

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        // TODO Sprint 3 Mod 05 - modify the ConsoleView constructor to accept the list of currency types
        /// <summary>
        /// constructor to create the console view, send all major data objects
        /// </summary>
        /// <param name="myPlayer">active player object</param>
        /// <param name="hall">current hall object</param>
        /// <param name="hall">current guest list object</param>
        public ConsoleView(Player myPlayer, Hall hall, GuestList guests, StaffList staff, List<CurrencyType> gameCurrency)
        {
            _myPlayer = myPlayer;
            _hall = hall;
            _guestList = guests;
            _staffList = staff;
            _gameCurrency = gameCurrency;
            InitializeConsoleWindow();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the console window with default settings
        /// </summary>
        public void InitializeConsoleWindow()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        }

        /// <summary>
        /// reset display to default size and colors including the header
        /// </summary>
        public void DisplayReset()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("The Deadly Dinner Party Game", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            Console.WriteLine(ConsoleUtil.Center("Press any key to continue.", WINDOW_WIDTH));
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt
        /// </summary>
        public void DisplayExitPrompt()
        {
            DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            DisplayMessage("Thank you for playing our game. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }

        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("Welcome to", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.Center("The Deadly Dinner Party Game", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of the player properties
        /// </summary>
        public void DisplayPlayerInformation()
        {
            DisplayReset();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("Your player information:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            DisplayMessage("Name: " + _myPlayer.Name);
            DisplayMessage("Race: " + _myPlayer.Race);
            DisplayMessage("Gender: " + _myPlayer.Gender);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of the guest properties
        /// </summary>
        /// <param name="guestNumber">the guestList array index</param>
        public void DisplayGuestInformation(int guestNumber)
        {
            Console.WriteLine();

            DisplayMessage("Name: " + _guestList.Guests[guestNumber].Name);
            DisplayMessage("Race: " + _guestList.Guests[guestNumber].Race);
            DisplayMessage("Gender: " + _guestList.Guests[guestNumber].Gender);
            DisplayMessage("Appears Friendly: " + _guestList.Guests[guestNumber].AppearsFriendly);
            DisplayMessage("Greeting: " + _guestList.Guests[guestNumber].InitialGreeting);
        }

        /// <summary>
        /// display a list of staff properties
        /// </summary>
        /// <param name="staffNumber">the staffList array index</param>
        public void DisplayStaffInformation(int staffNumber)
        {
            Console.WriteLine();

            DisplayMessage("Name: " + _staffList.Staff[staffNumber].Name);
            DisplayMessage("Race: " + _staffList.Staff[staffNumber].Race);
            DisplayMessage("Gender: " + _staffList.Staff[staffNumber].Gender);
            DisplayMessage("Appears Friendly: " + _staffList.Staff[staffNumber].AppearsFriendly);
            DisplayMessage("Greeting: " + _staffList.Staff[staffNumber].InitialGreeting);
        }

        /// <summary>
        /// display all of the rooms
        /// </summary>
        public void DisplayHallInformation()
        {
            DisplayReset();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("The Hall contains the following rooms:");
            Console.ForegroundColor = ConsoleColor.White;

            for (int roomNumber = 0; roomNumber < Hall.MAX_ROOMS; roomNumber++)
            {
                DisplayRoomInformation(roomNumber);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display this message to the player when in the hall
        /// </summary>
        public void DisplayHallMessage()
        {
            string hallMessage = "You are standing in a long hall. The hall has " +
                ControllerSettings.MAX_NUMBER_OF_ROOMS +
                " doors. Each door leads to one of the following rooms.";

            DisplayReset();
            Console.WriteLine();

            DisplayMessage(hallMessage);
            Console.WriteLine();

            for (int room = 0; room < ControllerSettings.MAX_NUMBER_OF_ROOMS; room++)
            {
                DisplayMessage(_hall.Rooms[room].Name);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display this message to the player when in a room
        /// </summary>
        public void DisplayRoomMessage()
        {

            DisplayReset();
            Console.WriteLine();

            DisplayMessage(_hall.Rooms[_myPlayer.CurrentRoomNumber].Description);
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display all of the guests
        /// </summary>
        public void DisplayGuestListInformation()
        {
            DisplayReset();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("The game contains the following guests:");
            Console.ForegroundColor = ConsoleColor.White;

            for (int guestNumber = 0; guestNumber < GuestList.MAX_NUMBER_OF_GUESTS; guestNumber++)
            {
                if (_guestList.Guests[guestNumber] != null)
                {
                    DisplayGuestInformation(guestNumber);
                }

            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display all of the staff
        /// </summary>
        public void DisplayStaffListInformation()
        {
            DisplayReset();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("The game contains the following staff:");
            Console.ForegroundColor = ConsoleColor.White;

            for (int staffNumber = 0; staffNumber < StaffList.MAX_NUMBER_OF_STAFF; staffNumber++)
            {
                if (_staffList.Staff[staffNumber] != null)
                {
                    DisplayStaffInformation(staffNumber);
                }

            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of the room properties
        /// </summary>
        /// <param name="roomNumber">the hall array index</param>
        public void DisplayRoomInformation(int roomNumber)
        {
            Console.WriteLine();
            DisplayMessage("Name: " + _hall.Rooms[roomNumber].Name);
            DisplayMessage("Description: " + _hall.Rooms[roomNumber].Description);
            DisplayMessage("Lighted: " + _hall.Rooms[roomNumber].IsLighted);
            DisplayMessage("Door Open: " + _hall.Rooms[roomNumber].CanEnter);
        }

        /// <summary>
        /// display a message in the message area
        /// </summary>
        /// <param name="message">string to display</param>
        public void DisplayMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            // message is not an empty line, display text
            if (message != "")
            {
                //
                // create a list of strings to hold the wrapped text message
                //
                List<string> messageLines;

                //
                // call utility method to wrap text and loop through list of strings to display
                //
                messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);
                foreach (var messageLine in messageLines)
                {
                    Console.WriteLine(messageLine);
                }
            }
            // display an empty line
            else
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// display a message in the message area without a new line for the prompt
        /// </summary>
        /// <param name="message">string to display</param>
        public void DisplayPromptMessage(string message)
        {
            //
            // calculate the message area location on the console window
            //
            const int MESSAGE_BOX_TEXT_LENGTH = WINDOW_WIDTH - (2 * DISPLAY_HORIZONTAL_MARGIN);
            const int MESSAGE_BOX_HORIZONTAL_MARGIN = DISPLAY_HORIZONTAL_MARGIN;

            //
            // create a list of strings to hold the wrapped text message
            //
            List<string> messageLines;

            //
            // call utility method to wrap text and loop through list of strings to display
            //
            messageLines = ConsoleUtil.Wrap(message, MESSAGE_BOX_TEXT_LENGTH, MESSAGE_BOX_HORIZONTAL_MARGIN);

            for (int lineNumber = 0; lineNumber < messageLines.Count() - 1; lineNumber++)
            {
                Console.WriteLine(messageLines[lineNumber]);
            }

            Console.Write(messageLines[messageLines.Count() - 1]);
        }

        /// <summary>
        /// provides a menu with options to display the information of the current objects in the game
        /// </summary>
        public void DisplayAllObjectInformation()
        {
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set a string varible with a lenght equal to the horizontal margin and filled with spaces
                //
                string leftTab = ConsoleUtil.FillStringWithSpaces(DISPLAY_HORIZONTAL_MARGIN);

                //
                // set up display area
                //
                DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                Console.WriteLine(
                    leftTab + "1. Player Information" + Environment.NewLine +
                    leftTab + "2. Hall Information" + Environment.NewLine +
                    leftTab + "3. Guest List Information" + Environment.NewLine +
                    leftTab + "4. Staff List Information" + Environment.NewLine +
                    leftTab + "5. Game Currency Types" + Environment.NewLine +
                    leftTab + "6. Player Treasure" + Environment.NewLine +
                    leftTab + "7. Player Weapons" + Environment.NewLine +
                    leftTab + "E. Exit" + Environment.NewLine);

                // TODO Sprint 3 Mod 08 - modify the DisplayAllObjectInformation to handle game currency
                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        DisplayPlayerInformation();
                        break;
                    case '2':
                        DisplayHallInformation();
                        break;
                    case '3':
                        DisplayGuestListInformation();
                        break;
                    case '4':
                        DisplayStaffListInformation();
                        break;
                    case '5':
                        DisplayGameCurrency();
                        break;
                    case '6':
                        DisplayPlayerTreasure();
                        break;
                    case '7':
                        DisplayPlayerWeapons();
                        break;
                    case 'E':
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to exit.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the available actions choices
        /// </summary>
        public void DisplayActionChoices()
        {
            DisplayMessage("You have the following actions available to you.");
            Console.WriteLine();

            foreach (Player.ActionChoice choice in Enum.GetValues(typeof(Player.ActionChoice)))
            {
                string actionChoiceText;

                // skip the first enum value that is the default value of "none"
                if (choice != Player.ActionChoice.None)
                {
                    actionChoiceText = "(" + ((int)choice) + ") " +
                        ConsoleUtil.ToLabelFormat(choice.ToString());
                    DisplayMessage(actionChoiceText);
                }
            }
        }

        // TODO Sprint 3 Mod 07 - add a DisplayGameCurrency method
        /// <summary>
        /// display all of the currency types
        /// </summary>
        public void DisplayGameCurrency()
        {
            DisplayReset();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("The game contains the currency types:");
            Console.ForegroundColor = ConsoleColor.White;
            DisplayMessage("");

            foreach (CurrencyType currency in _gameCurrency)
            {
                DisplayMessage("Currency Name: " + currency.Name);
                DisplayMessage("Currency Description: " + currency.Description);
                DisplayMessage("Currency Base Material: " + currency.BaseMaterial);
                DisplayMessage("Currency Value: " + currency.Value);
                DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        // TODO Sprint 3 Mod 14 - add a DisplayPlayerTreasure method
        /// <summary>
        /// display all of the currency types
        /// </summary>
        public void DisplayPlayerTreasure()
        {
            DisplayReset();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("The Player has the following treasure:");
            Console.ForegroundColor = ConsoleColor.White;
            DisplayMessage("");

            DisplayPlayerCurrency();

            DisplayContinuePrompt();
        }

        // TODO Sprint 3 Mod 12 - add a DisplayPlayerCurrency method
        /// <summary>
        /// display all of the currency types
        /// </summary>
        public void DisplayPlayerCurrency()
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("Currency:");
            Console.ForegroundColor = ConsoleColor.White;
            DisplayMessage("");

            foreach (PlayerCurrency currency in _myPlayer.Treasure.Currency)
            {
                DisplayMessage(currency.Quantity + " " + currency.CurrencyType.Name);
            }
        }

        // TODO Sprint 3 Mod 23 - add a DisplayPlayerWeapon method
        /// <summary>
        /// display all of the currency types
        /// </summary>
        public void DisplayPlayerWeapons()
        {
            DisplayReset();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("The Player has the following weapons:");
            Console.ForegroundColor = ConsoleColor.White;
            DisplayMessage("");

            foreach (Weapon weapon in _myPlayer.Weapons)
            {
                DisplayMessage("Weapon Name: " + weapon.Name);
                DisplayMessage("Weapon Type: " + weapon.Type);
                DisplayMessage("Weapon Description: " + weapon.Description);
                DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get player action choice
        /// </summary>
        /// <returns>player action choice enum</returns>
        public Player.ActionChoice GetPlayerAction()
        {
            int playerActionChoiceIndex;
            string playerResponse;
            bool validPlayerResponse = false;
            Player.ActionChoice playerActionChoice = Player.ActionChoice.None;

            while (!validPlayerResponse)
            {
                DisplayReset();
                Console.WriteLine();

                DisplayActionChoices();

                Console.WriteLine();
                DisplayPromptMessage("Enter the number for the action you would like to take: ");
                playerResponse = Console.ReadLine();

                // validate user's response
                if (
                    (Int32.TryParse(playerResponse, out playerActionChoiceIndex)) &&
                    (playerActionChoiceIndex != 0) &&
                    (playerActionChoiceIndex <= _myPlayer.ActionCount - 1)
                    )
                {
                    playerActionChoice = (Player.ActionChoice)playerActionChoiceIndex;

                    Console.WriteLine();
                    DisplayMessage("You have choosen the following action: " +
                        ConsoleUtil.ToLabelFormat(playerActionChoice.ToString()));
                    validPlayerResponse = true;

                    DisplayContinuePrompt();
                }
                else
                {
                    Console.WriteLine();

                    DisplayMessage("It appears that you have not provided a valid action." +
                        "Please use the number before each action to indicate your choice.");

                    DisplayContinuePrompt();
                }

            }

            return playerActionChoice;

        }

        /// <summary>
        ///  get player room number choice
        /// </summary>
        /// <returns>room number</returns>
        public int GetPlayerRoomNumberChoice()
        {
            int playerRoomNumberChoice = -1;
            string playerResponse;
            bool validPlayerResponse = false;

            while (!validPlayerResponse)
            {
                DisplayReset();

                Console.WriteLine();
                DisplayMessage("Choose one of the following rooms.");
                Console.WriteLine();

                int displayedRoomNumber;

                foreach (Room room in _hall.Rooms)
                {
                    // add one to the array indes to start the diplayed numbering at 1
                    displayedRoomNumber = Array.IndexOf(_hall.Rooms, room) + 1;

                    DisplayMessage("(" + displayedRoomNumber + ") " + room.Name);
                }

                Console.WriteLine();
                DisplayPromptMessage("Enter the number of the room you would like to enter: ");

                playerResponse = Console.ReadLine();

                // validate user's response
                if (
                    (Int32.TryParse(playerResponse, out playerRoomNumberChoice)) &&
                    (playerRoomNumberChoice > 0) &&
                    (playerRoomNumberChoice <= ControllerSettings.MAX_NUMBER_OF_ROOMS)
                    )
                {

                    // adjust the player's room number choice to match the array index
                    playerRoomNumberChoice--;

                    Console.WriteLine();
                    DisplayMessage("You have choosen the following room: " +
                        _hall.Rooms[playerRoomNumberChoice].Name);

                    validPlayerResponse = true;

                    DisplayContinuePrompt();
                }
                else
                {
                    Console.WriteLine();

                    DisplayMessage("It appears that you have not provided a valid room number." +
                        "Please use the number before each room's name to indicate your choice.");

                    DisplayContinuePrompt();
                }

            }

            return playerRoomNumberChoice;

        }

        #endregion
    }
}

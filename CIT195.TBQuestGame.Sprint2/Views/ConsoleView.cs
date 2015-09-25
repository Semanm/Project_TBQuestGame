﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint1
{
    public class ConsoleView
    {
        #region FIELDS

        //
        // window size
        //
        private const int WINDOW_WIDTH = 50;
        private const int WINDOW_HEIGHT = 40;

        //
        // horizontal and verical margins in console window for display
        //
        private const int DISPLAY_HORIZONTAL_MARGIN = 3;
        private const int DISPALY_VERITCAL_MARGIN = 1;

        //
        // declare the major data objects
        //
        private Player _myPlayer;
        private Hall _hall;
        private GuestList _guestList;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// constructor to create the console view, send all major data objects
        /// </summary>
        /// <param name="myPlayer">active player object</param>
        /// <param name="hall">current hall object</param>
        /// <param name="hall">current guest list object</param>
        public ConsoleView(Player myPlayer, Hall hall, GuestList guests)
        {
            _myPlayer = myPlayer;
            _hall = hall;
            _guestList = guests;
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
            Console.WriteLine(ConsoleUtil.Center("The Long Dinner Party Game", WINDOW_WIDTH));
            Console.WriteLine(ConsoleUtil.FillStringWithSpaces(WINDOW_WIDTH));

            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// display the Continue/Exit prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            DisplayMessage("Press any key to continue or press the ESC key to quit.");
            Console.WriteLine();

            ConsoleKeyInfo response = Console.ReadKey();
            if (response.Key == ConsoleKey.Escape)
            {
                System.Environment.Exit(1);
            }

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt
        /// </summary>
        public void DisplayExitPrompt()
        {
            Console.ResetColor();

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
            Console.WriteLine(ConsoleUtil.Center("The Long Dinner Party Game", WINDOW_WIDTH));
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
            DisplayMessage("Greeting: " + _guestList.Guests[guestNumber].Greeting);
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
        /// display all of the guests
        /// </summary>
        public void DisplayGuestListInformation()
        {
            DisplayReset();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            DisplayMessage("The game contains the following guests:");
            Console.ForegroundColor = ConsoleColor.White;

            for (int guestNumber = 0; guestNumber < GuestList.NUMBER_OF_GUESTS; guestNumber++)
            {
                DisplayGuestInformation(guestNumber);
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
                    leftTab + "4. Exit" + Environment.NewLine);

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

        #endregion
    }
}
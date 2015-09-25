using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint1
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
            _myPlayer = AddPlayer();
            _hall = new Hall();
            _guestList = new GuestList();
        }

        /// <summary>
        /// perform the game loop
        /// </summary>
        private void PlayGame()
        {
            //
            // instantiate a new ConsoleView object
            //
            ConsoleView userConsoleView = new ConsoleView(_myPlayer, _hall, _guestList);

            userConsoleView.DisplayWelcomeScreen();

            userConsoleView.DisplayAllObjectInformation();

            userConsoleView.DisplayReset();
            userConsoleView.DisplayExitPrompt();
        }

        /// <summary>
        /// instantiate the player and their properites
        /// </summary>
        /// <returns></returns>
        private Player AddPlayer()
        {
            Player myPlayer = new Player(
                "Bonzo",
                Player.GenderName.Female,
                Player.RaceName.Human,
                1);
            return myPlayer;
        }

        #endregion
    }
}

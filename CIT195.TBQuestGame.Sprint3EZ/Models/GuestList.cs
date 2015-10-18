using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CIT195.TBQuestGame.Sprint3EZ.Controllers;

namespace CIT195.TBQuestGame.Sprint3EZ
{
    /// <summary>
    /// class to manage an array of guests
    /// </summary>
    public class GuestList
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS

        public const int MAX_NUMBER_OF_GUESTS = ControllerSettings.MAX_NUMBER_OF_GUESTS;

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
            _guests = new Guest[MAX_NUMBER_OF_GUESTS];
        }

        #endregion

        #region METHODS


        #endregion
    }
}

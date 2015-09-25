using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint1
{
    /// <summary>
    /// class to manage an array of rooms
    /// </summary>
    public class Hall
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS

        public const int MAX_ROOMS = 4;

        private Room[] _rooms;


        #endregion

        #region PROPERTIES
        public Room[] Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Hall()
        {
            _rooms = new Room[MAX_ROOMS];
            InitializeRooms();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// instantiate and add the properties of the rooms
        /// </summary>
        private void InitializeRooms()
        {
            //
            // initialize array of rooms
            //
            for (int roomNumber = 0; roomNumber < MAX_ROOMS; roomNumber++)
            {
                _rooms[roomNumber] = new Room();
            }

            //
            // add room information
            //
            _rooms[0].Name = "The Great Hall";
            _rooms[0].Description = "You are in a large room with oak beams and dark wood panel.";
            _rooms[0].Type = Room.TypeName.Room;
            _rooms[0].IsLighted = true;
            _rooms[0].CanEnter = true;

            _rooms[1].Name = "The Master Bedroom";
            _rooms[1].Description = "You are in a large room with oak beams and dark wood panel.";
            _rooms[1].Type = Room.TypeName.Room;
            _rooms[1].IsLighted = false;
            _rooms[1].CanEnter = true;

            _rooms[2].Name = "The Kitchen";
            _rooms[2].Description = "You are in a large room with oak beams and dark wood panel.";
            _rooms[2].Type = Room.TypeName.Room;
            _rooms[2].IsLighted = true;
            _rooms[2].CanEnter = true;

            _rooms[3].Name = "The Armory";
            _rooms[3].Description = "You are in a room, crowed with racks of swords.";
            _rooms[3].Type = Room.TypeName.Room;
            _rooms[3].IsLighted = true;
            _rooms[3].CanEnter = true;
        }

        #endregion
    }
}

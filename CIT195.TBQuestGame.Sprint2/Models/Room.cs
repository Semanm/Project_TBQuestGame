using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint1
{
    /// <summary>
    /// class for the rooms in the game
    /// </summary>
    public class Room
    {
        #region ENUMERABLES

        public enum TypeName
        {
            Hall,
            Room,
            Courtyard
        }

        #endregion

        #region FIELDS

        private string _name;
        private TypeName _type;

        private bool _isLighted;
        private bool _canEnter;

        private string _description;

        private Guest[] _guests = new Guest[GuestList.NUMBER_OF_GUESTS];

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public TypeName Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public bool IsLighted
        {
            get { return _isLighted; }
            set { _isLighted = value; }
        }

        public bool CanEnter
        {
            get { return _canEnter; }
            set { _canEnter = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Guest[] Guests
        {
            get { return _guests; }
            set { _guests = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Room()
        {

        }

        #endregion

        #region METHODS

        public bool HasGuests()
        {
            if (_guests != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateRoomGuests()
        {
            foreach (Guest guest in Guests)
            {
                
            }
        }

        #endregion
    }
}

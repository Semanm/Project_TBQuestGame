using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint3
{
    // TODO Sprint 3 Mod 20 - add an GameItem base class
    public class GameItem
    {
        #region ENUMERABLES
        

        #endregion

        #region FIELDS

        private string _name;
        private string _description;

        #endregion

        #region PROPERTIES

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public GameItem()
        {

        }

        public GameItem(string name, string description)
        {
            _name = name;
            _description = description;
        }

        #endregion

        #region METHODS


        #endregion
    }
}

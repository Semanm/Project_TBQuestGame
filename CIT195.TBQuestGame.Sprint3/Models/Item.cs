using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.TBQuestGame.Sprint3
{
    public class Item
    {
        #region ENUMERABLES

        public enum Category
        {
            Coin,
            Key,
            Weapon,
            Tool
        }

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



        #endregion

        #region METHODS


        #endregion
    }
}

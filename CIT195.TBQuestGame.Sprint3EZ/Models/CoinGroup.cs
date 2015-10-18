using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT195.CIT195.TBQuestGame.Sprint3EZ
{
    /// <summary>
    /// class to hold groups of common coins
    /// </summary>
    public class CoinGroup
    {
        public int Quantity { get; set; }
        private Coin Coin;

        public Coin MyProperty
        {
            get { return Coin; }
            set { Coin = value; }
        }
        
    }
}

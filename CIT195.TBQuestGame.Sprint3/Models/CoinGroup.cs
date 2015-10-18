using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CIT195.TBQuestGame.Sprint3
{
    // TODO Sprint 3 Mod 03b - add a CoinGroup class to hold a coin type and quantity
    /// <summary>
    /// class to hold groups of common coins
    /// </summary>
    public class CoinGroup
    {
        public int Quantity { get; set; }
        public Coin CoinType { get; set; }
        
    }
}

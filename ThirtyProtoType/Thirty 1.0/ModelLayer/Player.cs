using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Player
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int PlayerNumber { get; set; }
        public int Score { get; set; }
        public int PlayersTurn { get; set; }
        public int Roll { get; set; }

        //Constructor with input variables
        public Player(string Name, string Type, int PlayerNumber)
        {
            this.Name = Name;
            this.Type = Type;
            this.PlayerNumber = PlayerNumber;
            this.Score = 0;
            this.PlayersTurn = 0;
            this.Roll = 0;
        }

        public Player()
        {
            this.Name = "";
            this.Type = "";
            this.PlayerNumber = 0;
            this.Score = 0;
            this.PlayersTurn = 0;
            this.Roll = 0;
        }

    }
}

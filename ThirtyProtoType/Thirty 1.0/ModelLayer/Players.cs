using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Players
    {
        public List<Player> PlayerList { get; set; }
        private static Players instance;

        private Players()
        {
            PlayerList = new List<Player>();
        }

        public static Players GetInstance()
        {
            if (instance == null)
            {
                instance = new Players();
            }
            return instance;
        }

        public void AddPlayer(Player player)
        {
            PlayerList.Add(player);
        }

        public Player FindPlayer(int playerNo)
        {
            Player player = PlayerList[playerNo];
            return player;
        }

        public void DeletePlayer(Player player)
        {
            if (player != null)
            {
                PlayerList.Remove(player);
            }
        }
    }
}

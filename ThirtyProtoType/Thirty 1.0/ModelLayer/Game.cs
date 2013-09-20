using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public enum State { running, thirty, gameover, canRoll }

    public class Game
    {
        public int Turn { get; set; }
        public int TableScore { get; set; }
        public List<Dice> GameDices { get; set; }
        public List<Player> GamePlayers { get; set; }
        public State _gameState { get; set; }

        public Game()
        {
            this.Turn = 0;
            this.TableScore = 0;
            this.GameDices = Dices.GetInstance().DiceList;
            this.GamePlayers = Players.GetInstance().PlayerList;
        }
    }
}

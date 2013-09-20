using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace LogicLayer
{
    public class GameCtr
    {
        public List<Player> PlayersInGame{ get; set; }
        public List<Dice> DicesInGame { get; set; }
        public Random rng { get; set; }
        public Game game { get; set; }

        public GameCtr()
        {
            this.game = new Game();
            this.PlayersInGame = game.GamePlayers;
            this.DicesInGame = game.GameDices;
            this.rng = new Random();
        }

        public void AddPlayer(string name, string type)
        {
            int playerNo = PlayersInGame.Count;
            playerNo++;
            if (playerNo > 2)
            {
                Console.WriteLine("only 2 players can join the game");
            }
            else
            {
                Player player = new Player(name, type, playerNo);
                PlayersInGame.Add(player);
            }
        }

        public void TrowDices()
        {
            //check statemachine that player is able to Roll again
            for (int i = 0; i <= DicesInGame.Count-1; i++)
            {
                {
                    if (DicesInGame[i].IsActive == true)
                    {
                        DicesInGame[i].Number = rng.Next(1, 7);
                    }
                    else
                    {
                        DicesInGame[i].Number = 0;
                    }
                }
            }
        }

        public void StartGame()
        {
            if (PlayersInGame.Count == 2)
            {
                game._gameState = State.running;
                this.AddDicesToGame();
                game.Turn = 1; //player no 1 starts the game
            }
        }

        public void AddDicesToGame()
        {
            int id1 = 1;
            int id2 = 2;
            int id3 = 3;
            int id4 = 4;
            int id5 = 5;
            int id6 = 6;

            Dice d1 = new Dice(id1);
            Dice d2 = new Dice(id2);
            Dice d3 = new Dice(id3);
            Dice d4 = new Dice(id4);
            Dice d5 = new Dice(id5);
            Dice d6 = new Dice(id6);

            DicesInGame.Add(d1);
            DicesInGame.Add(d2);
            DicesInGame.Add(d3);
            DicesInGame.Add(d4);
            DicesInGame.Add(d5);
            DicesInGame.Add(d6);
        }

        private void FinishTurn()
        {
            State gState = game._gameState;

            if (game._gameState != State.thirty)
            {
                int tSccore = game.TableScore;

                switch (tSccore)
                {
                    case 30:
                        game.TableScore = 0;
                        RotatePlayerTurn();
                        ActivateAllDices();
                        break;
                    case > 30:

                        break;
                }
            }

           
        }

        private void RotatePlayerTurn()
        {

        }

        private void ActivateAllDices()
        {

        }
    }
}

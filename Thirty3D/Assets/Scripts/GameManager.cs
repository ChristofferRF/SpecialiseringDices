using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {
	public List<Player> PlayersInGame { get; set; }
	public List<Dice> DicesInGame { get; set; }
    public Game game { get; set; }
    public Queue<Player> playerQueue { get; set; }
	private string name;
	
	private static GameManager instance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//get Singleton Instance of GameManager so that it can persist all data through all scenes
	public static GameManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject("GameManager").AddComponent<GameManager>();
			}
			return instance;
		}
	}
	
	//sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}
	
	//start op the GameManager
	public void StartState(string player1Name, string player2Name)
	{
		print("Creating a new game Manager instance");

        this.game = new GameObject("Game").AddComponent<Game>();
        this.PlayersInGame = game.GamePlayers;
        this.DicesInGame = game.GameDices;
        this.playerQueue = new Queue<Player>();
		game._gameState = Game.State.running;
//        this.AddDicesToGame();
        game.Turn = 1; //player no 1 starts the game
		AddPlayer(player1Name, "Human");
		AddPlayer(player2Name, "Human");
      
        SetupQueue();
	}
	
	private void AddPlayer(string name, string type)
	{
		Debug.Log("adding player to game");
        int playerNo = PlayersInGame.Count;
        playerNo++;
        if (playerNo > 2)
        {
            Debug.Log("more than 2 players in game - NO GO");
        }
        else
        {
            Player player = new GameObject("Player").AddComponent<Player>();
			player.Name = name;
			player.Type = type;
			player.PlayerNumber = playerNo;
            PlayersInGame.Add(player);
            if (player.PlayerNumber == 1)
            {
                game.playerWithTurn = player;
            }
        }
	}
	
	private void ThrowDices()
	{
		//check statemachine that player is able to Roll again
        for (int i = 0; i <= DicesInGame.Count-1; i++)
        {
            if (DicesInGame[i].IsActive == true)
            {
                DicesInGame[i].Number = Random.Range(1, 7);
            }
            else
            {
                DicesInGame[i].Number = 0;
            } 
        }
	}
	
	private void AddDicesToGame()
	{
		//for loop adding 6 dices to the game
		for(int i = 0; i < 5; i++)
		{
			Dice d = new GameObject("Dice").AddComponent<Dice>();
			d.Id = i;
			DicesInGame.Add(d);
		}
	}
	
	 public void FinishTurn()
        {
            if (game._gameState != Game.State.thirty)
            {
                int tSccore = game.TableScore;

                if(tSccore == 30)
                {
                    Debug.Log("tablescore is 30 finish turn and rotate player");
                    //player has reached 30 points and will get no minus points
                    ResetDicesTableScore();
                    RotatePlayerTurn();
                }
                else if (tSccore > 30 && tSccore < 37)
                {
                    //player has more than 30 in score and must go into thirty mode
                    game._gameState = Game.State.thirty;
                    //set thirty digit to roll with thirty switch
                    SetThirtyDigit(tSccore);
                    ResetDicesTableScore();


                }
                else if (tSccore < 30)
                {
                    //player has less than 30 in score and must receive minus points equal to difference to thity
                    int minusPoints = 30 - tSccore;
                    game.playerWithTurn.Score = game.playerWithTurn.Score + minusPoints;
                    ResetDicesTableScore();
 
                    RotatePlayerTurn();
                }   
            }
            Checkplayerscores();
        }
	
	public void finishThirty()
    {
        int tSccore = game.TableScore;
        if (tSccore == 0)
        {
            ResetDicesTableScore();
            game.ThirtyDigit = -1; //reset the thirty digit to default state
            game._gameState = Game.State.running;
            RotatePlayerTurn();
        }
        else
        {
            int subPoints = tSccore;
            //subtract points from the player who is next in queue, by using first method on Queue
            Player p = (Player)playerQueue.Peek();
            p.Score = p.Score + subPoints;
            ResetDicesTableScore();
            game.ThirtyDigit = -1; //reset the thirty digit to default state
            game._gameState = Game.State.running;
            RotatePlayerTurn();
        }
        Checkplayerscores();
    }
	
	private void RotatePlayerTurn()
    {
        Debug.Log("player with turn: " + game.playerWithTurn.PlayerNumber);
        Player p = playerQueue.Dequeue();
        game.playerWithTurn = p;
        playerQueue.Enqueue(game.playerWithTurn);
        Debug.Log("player to get turn: " + game.playerWithTurn.PlayerNumber);

    }
	
	private void SetupQueue()
    {
        //setup variable of playercount -1 to fit structure of list index of 0 -> 1
        int noOfPlayers = PlayersInGame.Count;

        for (int i = noOfPlayers; i-- > 0;)
        {
            Debug.Log("index: " + i);
            playerQueue.Enqueue(PlayersInGame[i]); //add all players in game to the stack backwards

        }
    }
	
	private void ResetDicesTableScore()
    {
        //reset the table score
        game.TableScore = 0;

        //reset all dices to be active
        foreach (Dice d in DicesInGame)
        {
            d.IsActive = true;
        }
    }
	
	private void SetThirtyDigit(int tableScore)
    {
        switch (tableScore)
        {
            case 31:
                game.ThirtyDigit = 1;
                break;
            case 32:
                game.ThirtyDigit = 2;
                break;
            case 33:
                game.ThirtyDigit = 3;
                break;
            case 34:
                game.ThirtyDigit = 4;
                break;
            case 35:
                game.ThirtyDigit = 5;
                break;
            case 36:
                game.ThirtyDigit = 6;
                break;
            default:
                break;
        }
    }
	
	 private void Checkplayerscores()
        {
            string playerNameWinner = "";
            int i = 0;

            while(i < PlayersInGame.Count)
            {
                if (PlayersInGame[i].Score == 30 || PlayersInGame[i].Score > 30)
                {
                    game._gameState = Game.State.gameover;
                    playerNameWinner = PlayersInGame[i].Name;
                }
                i++;
            }
        }
}

    



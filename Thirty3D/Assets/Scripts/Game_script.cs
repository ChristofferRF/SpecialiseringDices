using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Game_script : MonoBehaviour {
	public enum State { running, thirty, gameover, canRoll }
	public int Turn { get; set; }
    public int TableScore { get; set; }
    public State _gameState { get; set; }
    public Player_script playerWithTurn { get; set; }
    public int ThirtyDigit { get; set; }
    public bool canRoll { get; set; }
    public string winnerName { get; set; }
	private static Game_script gameInstance;
	
	// Use this for initialization
	void Start () {
//		this.Turn = 0;
//        this.TableScore = 0;
//        this.playerWithTurn = null;
//        this.ThirtyDigit = -1; //default state that shows no digits when game is not in thirty mode
//        this.canRoll = false; // boolean value that decides whether or not the player can roll again. 
//        this.winnerName = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//get Singleton Instance of GameManager so that it can persist all data through all scenes
	public static Game_script GameInstance
	{
		get
		{
			if(gameInstance == null)
			{
				gameInstance = new GameObject("Game_script").AddComponent<Game_script>();
			}
			return gameInstance;
		}
	}
	
	public void StartGameState()
	{
		this.Turn = 0;
        this.TableScore = 0;
        this.playerWithTurn = null;
        this.ThirtyDigit = -1; //default state that shows no digits when game is not in thirty mode
        this.canRoll = false; // boolean value that decides whether or not the player can roll again. 
        this.winnerName = "";
	}
}

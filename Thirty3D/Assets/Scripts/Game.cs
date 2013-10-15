using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Game : MonoBehaviour {
	public enum State { running, thirty, gameover, canRoll }
	public int Turn { get; set; }
    public int TableScore { get; set; }
    public List<Dice> GameDices { get; set; }
    public List<Player> GamePlayers { get; set; }
    public State _gameState { get; set; }
    public Player playerWithTurn { get; set; }
    public int ThirtyDigit { get; set; }
    public bool canRoll { get; set; }
    public string winnerName { get; set; }
	
	// Use this for initialization
	void Start () {
		this.Turn = 0;
        this.TableScore = 0;
        this.GameDices = Dices.GetInstance.DiceList;
        this.GamePlayers = Players.GetInstance().PlayerList;
        this.playerWithTurn = null;
        this.ThirtyDigit = -1; //default state that shows no digits when game is not in thirty mode
        this.canRoll = false; // boolean value that decides whether or not the player can roll again. 
        this.winnerName = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

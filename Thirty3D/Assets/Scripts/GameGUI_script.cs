using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameGUI_script : MonoBehaviour {
	public Texture2D dice1Png;
	public Texture2D dice2Png;
	public Texture2D dice3Png;
	public Texture2D dice4Png;
	public Texture2D dice5Png;
	public Texture2D dice6Png;
	public Texture2D diceThirtyPng;
	public Texture2D p1Png;
	public Texture2D p2Png;
	public string p1Name;
	public string p2Name;
	private GameManager_script gameMng;
	private Dictionary<int, Texture2D> diceImages;
	private bool d1 = false;
	private bool d2 = false;
	private bool d3 = false;
	private bool d4 = false;
	private bool d5 = false;
	private bool d6 = false;
	private bool rolled = false;
	private bool finish = false;
	private bool p1Turn = false;
	private bool p2Turn = false;
	private bool inThirtyMode = false;
	private Texture2D playerTurnPng;

	
	
	// Use this for initialization
	void Start () {
		RollDices();
	
		p1Png = Resources.Load("PlayerNo1") as Texture2D;
		p2Png = Resources.Load("PlayerNo2") as Texture2D;
		playerTurnPng = Resources.Load("PlayerTurn") as Texture2D;
//		GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
//		p1Name = gameManager.GetComponent<GameManager_script>()..Instance.FindPlayer(0).Name;
//		Debug.Log(p1Name);
//		p2Name = gameManager.Instance.FindPlayer(1).Name;
//		Debug.Log(p1Name);
		p1Name = gameMng.FindPlayer(0).Name;
		p2Name = gameMng.FindPlayer(1).Name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
	{	
		GUI.BeginGroup(new Rect(0,0, Screen.width, Screen.height));
				
		if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-50,56.5f,55.75f),dice1Png)) d1 = true;
		{
			DiceClickedEvent(0, d1);
		}
        if(GUI.Button(new Rect(Screen.width/2-30,Screen.height/2-50,56.5f,55.75f),dice2Png))d2 = true;
		{
			DiceClickedEvent(1, d2);
		}
    	if(GUI.Button(new Rect(Screen.width/2+40,Screen.height/2-50,56.5f,55.75f),dice3Png))d3 = true;
		{
			DiceClickedEvent(2, d3);
		}
    	if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2+50,56.5f,55.75f),dice4Png))d4 = true;
		{
			DiceClickedEvent(3, d4);
		}
    	if(GUI.Button(new Rect(Screen.width/2-30,Screen.height/2+50,56.5f,55.75f),dice5Png))d5 = true;
		{
			DiceClickedEvent(4, d5);
		}
    	if(GUI.Button(new Rect(Screen.width/2+40,Screen.height/2+50,56.5f,55.75f),dice6Png))d6 = true;
		{
			DiceClickedEvent(5, d6);
		}
	                  
	   	//Exit buttons for testing purposes
		if(GUI.Button(new Rect(Screen.width/2 + 150,Screen.height/2,100,50), "Exit game"))
			Application.Quit();
		if(GUI.Button(new Rect(Screen.width/2 + 150,Screen.height/2 + 50,100,50), "Back to Main"))
		{
			Application.LoadLevel(0);
		}
		GUI.EndGroup();
		
		//game items
		GUI.BeginGroup(new Rect(0,0, Screen.width, Screen.height));
		
		GUI.Box(new Rect(Screen.width/2-50,Screen.height/2+12.5f,100,25), "");
		GUI.Label(new Rect(Screen.width/2 - 43,Screen.height/2+14,100,25), "Table Score: " + gameMng.game.TableScore.ToString());
		
		//Button that rolls the dices        
		if(GUI.Button(new Rect(Screen.width/2-110,Screen.height/2+12.5f,50,25), "Roll")) rolled = true;
		{
			if(rolled)
			{
				RollDices();
				Debug.Log("Dice is rolled");
				rolled = false;
			}
			
		}
	
		//Button to end players turn and give turn to next player        
		if(GUI.Button(new Rect(Screen.width/2+58,Screen.height/2+12.5f,50,25), "Finish")) finish = true;
		{
			if(finish)
			{
				if(gameMng.game._gameState == Game_script.State.thirty)
				{
					Debug.Log("Whoa in thirty mode!");
					gameMng.finishThirty();
					RollDices();
					finish = false;
				}
				else {
					Debug.Log("turn is finished, next players turn");
					gameMng.FinishTurn();
					Debug.Log("gamestate is changed to: " + gameMng.game._gameState.ToString());
					RollDices();
					finish = false;
				}
			}
			
		}
		GUI.EndGroup();
		
		//player 1 plate
		GUI.BeginGroup(new Rect(0,0, Screen.width, Screen.height));
		GUI.Box(new Rect(Screen.width/2-70,Screen.height/2+180,120,50),"");
		GUI.Box(new Rect(Screen.width/2-65,Screen.height/2+190,30,30), p1Png);
		GUI.Label(new Rect(Screen.width/2-25,Screen.height/2+185,125,30), p1Name);
		GUI.Label(new Rect(Screen.width/2-25,Screen.height/2+205,125,30), gameMng.FindPlayer(0).Score.ToString());
		if(gameMng.game.playerWithTurn.PlayerNumber == 1)
		{
			GUI.Box(new Rect(Screen.width/2+15,Screen.height/2+190,30,20), playerTurnPng);
		}
		GUI.EndGroup();
		
		//player 2 plate
		GUI.BeginGroup(new Rect(0,0, Screen.width, Screen.height));
		GUI.Box(new Rect(Screen.width/2-70,Screen.height/2-220,120,50),"");
		GUI.Box(new Rect(Screen.width/2-65,Screen.height/2-210,30,30), p2Png);
		GUI.Label(new Rect(Screen.width/2-25,Screen.height/2-215,125,30), p2Name);
		GUI.Label(new Rect(Screen.width/2-25,Screen.height/2-195,125,30), gameMng.FindPlayer(1).Score.ToString());
		if(gameMng.game.playerWithTurn.PlayerNumber == 2)
		{
			GUI.Box(new Rect(Screen.width/2+15,Screen.height/2-210,30,20), playerTurnPng);
		}
		GUI.EndGroup();
		
		//Thirty mode panel
		GUI.BeginGroup(new Rect(0,0, Screen.width, Screen.height));
		if(gameMng.game._gameState.Equals(Game_script.State.thirty))
		{
			SetThirtyDice();
			GUI.Box(new Rect(Screen.width/2-250,Screen.height/2-30,120,100),"Thirty Mode");
			GUI.Box(new Rect(Screen.width/2-220,Screen.height/2,56.5f,55.75f),diceThirtyPng);
		}
		
		
		
		GUI.EndGroup();
	}

	
	void Awake()
	{
		
		gameMng = GameManager_script.ManagerInstance;
		gameMng.ThrowDices();
		diceImages = new Dictionary<int, Texture2D>();
	
		diceImages.Add(1, Resources.Load("Dice1") as Texture2D);
		diceImages.Add(2, Resources.Load("Dice2") as Texture2D);
		diceImages.Add(3, Resources.Load("Dice3") as Texture2D);
		diceImages.Add(4, Resources.Load("Dice4") as Texture2D);
		diceImages.Add(5, Resources.Load("Dice5") as Texture2D);
		diceImages.Add(6, Resources.Load("Dice6") as Texture2D);
		diceImages.Add(7, Resources.Load("Scored_1") as Texture2D);
		RollDices();
	}
	
	public void RollDices()
	{
		gameMng.ThrowDices();
		
		foreach(Dice_script d in gameMng.DicesInGame)
		{
			
			switch(d.Id)
			{
			case 1:
				if(gameMng.DicesInGame[0].IsActive == true)
				{
					dice1Png = diceImages[d.Number];
				}
				break;
			case 2:
				if(gameMng.DicesInGame[1].IsActive == true)
				{
					dice2Png = diceImages[d.Number];
				}
				break;
			case 3:
				if(gameMng.DicesInGame[2].IsActive == true)
				{
					dice3Png = diceImages[d.Number];
				}
				break;
			case 4:
				if(gameMng.DicesInGame[3].IsActive == true)
				{
					dice4Png = diceImages[d.Number];
				}
				break;
			case 5:
				if(gameMng.DicesInGame[4].IsActive == true)
				{
					dice5Png = diceImages[d.Number];
				}
				break;
			case 6:
				if(gameMng.DicesInGame[5].IsActive == true)
				{
					dice6Png = diceImages[d.Number];
				}
				break;
			}
		}
	}
	
	public Dictionary<int, Texture2D> DiceImages
	{
		get{return diceImages;}
		set{diceImages = value;}
	}
	
//	private void OnDiceClick(int diceId)
//        {
//            int tableScore = gameMng.game.TableScore;
//            
//            if (gameMng.game._gameState == Game_script.State.thirty)
//            {
//                //game is in thirty mode
//
//               Debug.Log ("Thirty mode banking");
//                
//                
//                Dice_script d = gameMng.GetDice(diceId);
//				int digitToCheck = d.Number;
//                if (digitToCheck == gameMng.game.ThirtyDigit)
//                {
//                    Debug.Log ("yeah great succes");
//
//                    tableScore = tableScore + d.Number;
//                    gameMng.game.TableScore = tableScore;
////                    tableScore = tableScore;
//
//                    d.IsActive = false;
//                    buttonSwitch(diceId);
//                    gameMng.game.canRoll = true;
//                }
//                
//               
//            }
//            else
//            {
//                if (tableScore > 30)
//                {
//                    //check if there is more active dices. if there isnt, show this msg.
//                    
//                    Debug.Log("Finish your Turn");
//                }
//                else
//                {
//                   
//                    
//                    Dice_script d = gameMng.GetDice(diceId);
//
//                    tableScore = tableScore + d.Number;
//                    gameMng.game.TableScore = tableScore;
////                    tableScore = tableScore.ToString();
//                    
//                    d.IsActive = false;
//                    buttonSwitch(diceId);
//                    gameMng.game.canRoll = true;
//                } 
//            }
//        }
	
	private void DiceClickedEvent(int diceIndex, bool diceBool)
	{
		if(diceBool)
		{
			if(gameMng.game._gameState == Game_script.State.thirty)
			{
				Dice_script d = gameMng.DicesInGame[diceIndex];
				int digitCheck = d.Number;
				if(gameMng.DicesInGame[diceIndex].IsActive == true && digitCheck == gameMng.game.ThirtyDigit)
				{
					Debug.Log("succes digit matches");
					gameMng.DicesInGame[diceIndex].IsActive = false;
					gameMng.game.TableScore = gameMng.game.TableScore + gameMng.DicesInGame[diceIndex].Number;
					DiceBoolSwitch(diceIndex);
				}
				else {
					Debug.Log("Digit doesnt match");
				}
			}
			else {
				if(gameMng.DicesInGame[diceIndex].IsActive == true && gameMng.game._gameState == Game_script.State.running)
				{
					gameMng.DicesInGame[diceIndex].IsActive = false;
					gameMng.game.TableScore = gameMng.game.TableScore + gameMng.DicesInGame[diceIndex].Number;
					Debug.Log (gameMng.DicesInGame[diceIndex].Number.ToString());
					DiceBoolSwitch(diceIndex);
				}
				else{
					Debug.Log ("Dice no: " + gameMng.DicesInGame[diceIndex].Id+ " isnt active");
					
				}
			}
		}
	}
	
	private void DiceBoolSwitch(int diceIndex)
	{
		switch(diceIndex)
		{
			case 0:
				dice1Png = diceImages[7];
				d1 = false;
			Debug.Log("d1: " + d1.ToString());
				break;
			case 1:
				dice2Png = diceImages[7];
				d2 = false;
			Debug.Log("d2: " + d2.ToString());
				break;
			case 2:
				dice3Png = diceImages[7];
				d3 = false;
			Debug.Log("d3: " + d3.ToString());
				break;
			case 3:
				dice4Png = diceImages[7];
				d4 = false;
			Debug.Log("d4: " + d4.ToString());
				break;
			case 4:
				dice5Png = diceImages[7];
				d5 = false;
			Debug.Log("d5: " + d5.ToString());
				break;
			case 5:
				dice6Png = diceImages[7];
				d6 = false;
			Debug.Log("d6: " + d6.ToString());
				break;
		}
	}
	
	private void SetThirtyDice()
	{
		int digit = gameMng.game.ThirtyDigit;
		
		switch(digit)
		{
			case 1:
				diceThirtyPng = Resources.Load("Dice1") as Texture2D;
				break;
			case 2:
				diceThirtyPng = Resources.Load("Dice2") as Texture2D;
				break;
			case 3:
				diceThirtyPng = Resources.Load("Dice3") as Texture2D;
				break;
			case 4:
				diceThirtyPng = Resources.Load("Dice4") as Texture2D;
				break;
			case 5:
				diceThirtyPng = Resources.Load("Dice5") as Texture2D;
				break;
			case 6:
				diceThirtyPng = Resources.Load("Dice6") as Texture2D;
				break;
		}
	}
}

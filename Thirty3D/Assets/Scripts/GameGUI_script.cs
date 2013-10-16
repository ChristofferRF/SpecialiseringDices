using UnityEngine;
using System.Collections;

public class GameGUI_script : MonoBehaviour {
	public Texture2D dice1Png;
	public Texture2D dice2Png;
	public Texture2D dice3Png;
	public Texture2D dice4Png;
	public Texture2D dice5Png;
	public Texture2D dice6Png;
	public Texture2D p1Png;
	public Texture2D p2Png;
	public string p1Name;
	public string p2Name;
	
	// Use this for initialization
	void Start () {
		dice1Png = Resources.Load("Dice1") as Texture2D;
		dice2Png = Resources.Load("Dice2") as Texture2D;
		dice3Png = Resources.Load("Dice3") as Texture2D;		
		dice4Png = Resources.Load("Dice4") as Texture2D;
		dice5Png = Resources.Load("Dice5") as Texture2D;
		dice6Png = Resources.Load("Dice6") as Texture2D;
		p1Png = Resources.Load("PlayerNo1") as Texture2D;
		p2Png = Resources.Load("PlayerNo2") as Texture2D;
//		GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
//		p1Name = gameManager.GetComponent<GameManager_script>()..Instance.FindPlayer(0).Name;
//		Debug.Log(p1Name);
//		p2Name = gameManager.Instance.FindPlayer(1).Name;
//		Debug.Log(p1Name);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{	
		GUI.BeginGroup(new Rect(0,0, Screen.width, Screen.height));
		
		GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-50,56.5f,55.75f), dice1Png);
		GUI.Button(new Rect(Screen.width/2-30,Screen.height/2-50,56.5f,55.75f), dice2Png);
		GUI.Button(new Rect(Screen.width/2+40,Screen.height/2-50,56.5f,55.75f), dice3Png);
		GUI.Button(new Rect(Screen.width/2-100,Screen.height/2+50,56.5f,55.75f), dice4Png);
		GUI.Button(new Rect(Screen.width/2-30,Screen.height/2+50,56.5f,55.75f), dice5Png);
		GUI.Button(new Rect(Screen.width/2+40,Screen.height/2+50,56.5f,55.75f), dice6Png);
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+12.5f,100,25), "Roll"))
			print("Dice is rolled");
		
		
		if(GUI.Button(new Rect(Screen.width/2 + 150,Screen.height/2,100,50), "Exit game"))
			Application.Quit();
		if(GUI.Button(new Rect(Screen.width/2 + 150,Screen.height/2 + 50,100,50), "Back to Main"))
			Application.LoadLevel(0);
		GUI.EndGroup();
		
		//game items
		GUI.BeginGroup(new Rect(0,0, Screen.width, Screen.height));
		GUI.Label(new Rect(Screen.width/2 - 200,Screen.height/2,100,50), Game_script.GameInstance.TableScore.ToString());
		GUI.Label(new Rect(Screen.width/2 - 200,Screen.height/2+20,100,50), Game_script.GameInstance.canRoll.ToString());
		GUI.EndGroup();
		
		//player 1 plate
		GUI.BeginGroup(new Rect(0,0, Screen.width, Screen.height));
		GUI.Box(new Rect(Screen.width/2-70,Screen.height/2+180,120,50),"");
		GUI.Box(new Rect(Screen.width/2-65,Screen.height/2+190,30,30), p1Png);
		GUI.Label(new Rect(Screen.width/2-25,Screen.height/2+185,125,30), p1Name);
		GUI.Label(new Rect(Screen.width/2-25,Screen.height/2+205,125,30), "score: 0");
		GUI.EndGroup();
		
		//player 2 plate
		GUI.BeginGroup(new Rect(0,0, Screen.width, Screen.height));
		GUI.Box(new Rect(Screen.width/2-70,Screen.height/2-220,120,50),"");
		GUI.Box(new Rect(Screen.width/2-65,Screen.height/2-210,30,30), p2Png);
		GUI.Label(new Rect(Screen.width/2-25,Screen.height/2-215,125,30), p2Name);
		GUI.Label(new Rect(Screen.width/2-25,Screen.height/2-195,125,30), "score: 0");
		GUI.EndGroup();
	}
}

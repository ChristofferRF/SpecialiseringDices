using UnityEngine;
using System.Collections;

public class StartMainMenu : MonoBehaviour {
	public Texture2D player1Png;
	public Texture2D player2Png;
	public string player1Name;
	public string player2Name;
		

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		//game Title
		GUI.Label(new Rect(0 + Screen.width/2 - 65, 0 + Screen.height/2 -200,150,30),"Thirty - Dice game");
		
		//player one box
		GUI.BeginGroup(new Rect(0, 0, Screen.width,Screen.height));
		GUI.Box(new Rect(0 + Screen.width/2 - 175, 0 + Screen.height/2 -135,350,50), "");
		player1Name = GUI.TextField(new Rect(0 + Screen.width/2 - 75, 0 + Screen.height/2 -125,150,30),"Player 1");
		GUI.Label(new Rect(0 + Screen.width/2 - 160, 0 + Screen.height/2 -120,150,30),"1");
		GUI.Label(new Rect(0 + Screen.width/2 - 120, 0 + Screen.height/2 -135,150,50),player1Png);
		GUI.EndGroup();
		
		//player two box
		GUI.BeginGroup(new Rect(0, 0, Screen.width,Screen.height));
		GUI.Box(new Rect(0 + Screen.width/2 - 175, 0 + Screen.height/2 -75,350,50), "");
		player2Name = GUI.TextField(new Rect(0 + Screen.width/2 - 75, 0 + Screen.height/2 -65,150,30),"Player 2");
		GUI.Label(new Rect(0 + Screen.width/2 - 160, 0 + Screen.height/2 -60,150,30),"2");
		GUI.Label(new Rect(0 + Screen.width/2 - 120, 0 + Screen.height/2 -75,150,50),player2Png);
		GUI.EndGroup();
		
		GUI.BeginGroup(new Rect(0, 0, Screen.width,Screen.height));
			GUI.Box(new Rect(0, 0, Screen.width,Screen.height), "Main Menu");
			if(GUI.Button(new Rect(0 + Screen.width/2 - 65, 0 + Screen.height/2, 130, 50), "Start Game"))
			{
			
				Application.LoadLevel ("sceneProto"); 
			}
			if(GUI.Button(new Rect(0 + Screen.width/2 - 65, (0 + Screen.height/2) + 60, 130, 50), "Exit Game"))
			{
				Application.Quit();
			}
		GUI.EndGroup();
	}
}

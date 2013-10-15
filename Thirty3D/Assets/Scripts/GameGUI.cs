using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	public Texture2D dice1Png;
	public Texture2D dice2Png;
	public Texture2D dice3Png;
	public Texture2D dice4Png;
	public Texture2D dice5Png;
	public Texture2D dice6Png;
	
	// Use this for initialization
	void Start () {
		dice1Png = Resources.Load("Dice1") as Texture2D;
		dice2Png = Resources.Load("Dice2") as Texture2D;
		dice3Png = Resources.Load("Dice3") as Texture2D;		
		dice4Png = Resources.Load("Dice4") as Texture2D;
		dice5Png = Resources.Load("Dice5") as Texture2D;
		dice6Png = Resources.Load("Dice6") as Texture2D;		
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
	}
}

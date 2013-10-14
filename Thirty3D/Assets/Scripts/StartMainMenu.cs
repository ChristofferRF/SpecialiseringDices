using UnityEngine;
using System.Collections;

public class StartMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.BeginGroup(new Rect(0, 0, Screen.width,Screen.height));
			GUI.Box(new Rect(0, 0, Screen.width,Screen.height), "Main Menu");
			if(GUI.Button(new Rect(0 + Screen.width/2, 0 + Screen.height/2, 125, 50), "Start Game"))
			{
				Application.LoadLevel ("sceneProto"); 
			}
		if(GUI.Button(new Rect(0 + Screen.width/2, (0 + Screen.height/2) + 60, 125, 50), "Exit Game"))
		{
			Application.Quit();
		}
		GUI.EndGroup();
	}
}

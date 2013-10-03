using UnityEngine;
using System.Collections;

public class TheNotes : MonoBehaviour {
	
	//make a background box
	void OnGUI()
	{
		GUI.Box (Rect (10,10,100,90), "Loader Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
	if (GUI.Button (Rect (20,40,80,20), "Level 1")) {
		Application.LoadLevel (1);
	}

	// Make the second button.
	if (GUI.Button (Rect (20,70,80,20), "Level 2")) {
		Application.LoadLevel (2);
	}
	
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

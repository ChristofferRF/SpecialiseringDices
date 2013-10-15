using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {
	public int number;
	public int id;
	public bool isActive;
	public Texture2D dicePng;
	public float x;
	public float y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		GUI.Button(new Rect(x,y,56.5f,55.75f), dicePng);
	}
		
}

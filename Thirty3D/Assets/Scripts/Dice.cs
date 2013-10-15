﻿using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour {
	public int Number { get; set; }
    public int Id { get; set; }
    public bool IsActive { get; set; }
	public Texture2D dicePng;
	public float x;
	public float y;

	// Use this for initialization
	void Start () {
		this.Number = 0;
		this.IsActive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		GUI.Button(new Rect(x,y,56.5f,55.75f), dicePng);
	}
		
}

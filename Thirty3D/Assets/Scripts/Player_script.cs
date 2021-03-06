﻿using UnityEngine;
using System.Collections;

public class Player_script : MonoBehaviour {
	public string Name {get; set;}
	public string Type { get; set; }
    public int PlayerNumber { get; set; }
    public int Score { get; set; }
    public int PlayersTurn { get; set; }
    public int Roll { get; set; }
	private static Player_script playerInstance;
	
	
	// Use this for initialization
	void Start () {
//		this.Name = "";
//        this.Type = "";
//        this.PlayerNumber = 0;
//        this.Score = 0;
//        this.PlayersTurn = 0;
//        this.Roll = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake()
	{
		this.Name = "";
        this.Type = "";
        this.PlayerNumber = 0;
        this.Score = 30;
        this.PlayersTurn = 0;
        this.Roll = 0;
	}
	
	public static Player_script PlayerInstance
	{
		get
		{
			if(playerInstance == null)
			{
				playerInstance = new GameObject("Player_script").AddComponent<Player_script>();
			}
			return playerInstance;
		}
	}
}

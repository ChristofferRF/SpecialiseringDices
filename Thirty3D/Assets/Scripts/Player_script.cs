using UnityEngine;
using System.Collections;

public class Player_script : MonoBehaviour {
	public string Name {get; set;}
	public string Type { get; set; }
    public int PlayerNumber { get; set; }
    public int Score { get; set; }
    public int PlayersTurn { get; set; }
    public int Roll { get; set; }
	
	
	// Use this for initialization
	void Start () {
		this.Name = "";
        this.Type = "";
        this.PlayerNumber = 0;
        this.Score = 0;
        this.PlayersTurn = 0;
        this.Roll = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Players : MonoBehaviour {
	public List<Player> PlayerList { get; set; }
    private static Players instance;
	// Use this for initialization
	void Start () {
		PlayerList = new List<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static Players GetInstance()
    {
        if (instance == null)
        {
            instance = new GameObject("Players").AddComponent<Players>();
        }
        return instance;
    }
	
	public void AddPlayer(Player player)
    {
        PlayerList.Add(player);
    }

    public Player FindPlayer(int playerNo)
    {
        Player player = PlayerList[playerNo];
        return player;
    }

    public void DeletePlayer(Player player)
    {
        if (player != null)
        {
            PlayerList.Remove(player);
        }
    }
}

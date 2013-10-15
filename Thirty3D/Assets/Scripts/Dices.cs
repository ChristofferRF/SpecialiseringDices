using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dices : MonoBehaviour {
	public List<Dice> DiceList { get; set; }
    private static Dices instance;

	// Use this for initialization
	void Start () {
		DiceList = new List<Dice>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static Dices GetInstance()
    {
        if(instance == null) {
            instance = new GameObject("Dices").AddComponent<Dices>();
        }
        return instance;
    }
	
	public Dice GetDice(int diceId)
    {
        int index = 0;
        bool found = false;
        Dice d = null;

        while (index < DiceList.Count && !found)
        {
            d = DiceList[index];
            if (d.Id == diceId)
            {
                found = true;
            }
            else
            {
                index++;
            }
        }
        return d;
    }
}

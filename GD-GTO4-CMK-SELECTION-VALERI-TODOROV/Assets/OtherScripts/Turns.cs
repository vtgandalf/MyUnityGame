using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour {
    private int turnCounter;
	void Start () {
        turnCounter = 0;
	}
	void Update () {
		
	}
    public int TurnCounter
    {
        get { return this.turnCounter; }
        private set { this.turnCounter = value; }
    }
    public void NextTurn()
    {
        this.TurnCounter++;
    }
}

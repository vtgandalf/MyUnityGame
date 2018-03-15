using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int numberOfPlayers;
    System.Random random = new System.Random();
    private List<Player> playerList = new List<Player>();
    private int currentPlayer;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            float r = this.random.Next(0, 11);
            float g = this.random.Next(0, 11);
            float b = this.random.Next(0, 11);
            Color color = new Color(r/10, g/10, b/10);
            Player player = new Player(color);
            this.playerList.Add(player);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public List<Player> PlayerList
    {
        get { return this.playerList; }
    }

    public int CurrentPlayer
    {
        get { return this.currentPlayer; }
        set { this.currentPlayer = value; }
    }

    public void CurrentChange()
    {
        if (CurrentPlayer == PlayerList.Count-1)
        {
            CurrentPlayer = 0;
        }
        else
        {
            CurrentPlayer++;
        }
    }
}

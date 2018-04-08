using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    private int health;
    private int dmg;

    public Stats(int health,int dmg)
    {
        Health = health;
        Dmg = dmg;
    }
    public int Health
    {
        get { return this.health; }
        set { this.health = value; }
    }
    public int Dmg
    {
        get { return this.dmg; }
        set { this.dmg = value; }
    }
    public void TakeDmg(int dmg)
    {
        Health = Health - dmg;
    }
    public void Heal(int dmg)
    {
        Health = Health + dmg;
    }
    public string Info()
    {
        string info = "HP: " + Health.ToString() + "%";
        return info;
    }
}

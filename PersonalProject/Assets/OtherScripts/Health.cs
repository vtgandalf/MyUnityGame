using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    private int hp;
    void Start()
    {
        Hp = 20;
    }
    public int Hp
    {
        get { return this.hp; }
        set { this.hp = value; }
    }
}

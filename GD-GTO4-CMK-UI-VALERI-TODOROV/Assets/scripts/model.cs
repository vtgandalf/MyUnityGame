using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class model : MonoBehaviour {

    private int hp;
    public int step;

    public void Start()
    {
        this.hp = 100;
    }
    public void AddHp()
    {
        if(this.hp + step>100)
        {
            this.hp = 100;
        }
        else
        {
            this.hp = this.hp + step;
        }
    }
    public void SubstractHp()
    {
        this.hp = this.hp - step;
        if (this.hp - step < 0)
        {
            this.hp = 0;
        }
        else
        {
            this.hp = this.hp - step;
        }
    }
    public int Hp
    {
        get { return this.hp; }
    }
}

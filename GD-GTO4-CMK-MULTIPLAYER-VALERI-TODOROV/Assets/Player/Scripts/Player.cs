using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Color color;
    private ResourceList resourceList = new ResourceList();
    private bool isDead;
    private UnitList unitList = new UnitList();

    //public Color Color
    //{
    //    get { return this.color; }
    //    set { this.color = value; }
    //}
    public Player(Color color)
    {
        //Color = color;
        this.color = color;
        IsDead = false;
    }
    public ResourceList ResourceList
    {
        get { return this.resourceList; }
    }
    public bool IsDead
    {
        get { return this.isDead; }
        set { this.isDead = value; }
    }
    public Color Color
    {
        get { return this.color; }
    }
    public UnitList UnitList
    {
        get { return this.unitList; }
    }
}

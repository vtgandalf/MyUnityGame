using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int X;
    public int Y;
    private bool inUse = false;
    private bool enemy = false;
    private bool health = false;
    private bool finish = false;
    Color def;
   // private Material material;
    //private Renderer rend;
    void Start()
    {
        //rend = this.gameObject.GetComponent<Renderer>();
        //this.material = rend.material;
        // Cell parent = this.gameObject.GetComponentInParent<Cell>();
        //InUse = false;
        def = gameObject.GetComponent<Renderer>().material.color;
    }

    public void Hovered()
    {
        //rend.material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void GetNeutral()
    {
        //rend.material.shader = Shader.Find("Diffuse");
        GetComponent<Renderer>().material.color = def;
    }

    public void Selected()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void OutOfReach()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
    public bool InUse
    {
        get { return this.inUse; }
        set { this.inUse = value; }
    }
    public bool Enemy
    {
        get { return this.enemy; }
        set { this.enemy = value; }
    }
    public bool Health
    {
        get { return this.health; }
        set { this.health = value; }
    }
    public bool Finish
    {
        get { return this.finish; }
        set { this.finish = value;}
    }
}

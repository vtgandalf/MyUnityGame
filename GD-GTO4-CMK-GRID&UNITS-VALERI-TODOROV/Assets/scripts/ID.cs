using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID : MonoBehaviour {
    public int id;
    public TileScript obj;
    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }
    public TileScript Obj
    {
        get { return this.obj; }
        set { this.obj = value; }
    }
    
    public ID(int id, TileScript obj)
    {
        Id = id;
        Obj = obj;
    }
}

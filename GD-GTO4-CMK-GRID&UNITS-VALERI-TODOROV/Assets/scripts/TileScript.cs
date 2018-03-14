using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    //public float x;
    //public float y;
    //public float z;
    private Vector3 position;
    private Vector3 size;
    private bool unitInUse;
    private int id;

    void Start()
    {
        //position = transform.position;
        //UpdatePosition();
        size = this.GetComponent<Collider>().bounds.size;
        unitInUse = false;
    }
    void Update()
    {
        //UpdatePosition();
    }
    void UpdatePosition()
    {
        this.gameObject.transform.position = this.position;
    }
    public Vector3 Size
    {
        get { return this.size; }
    }
    public bool UnitInUse
    {
        get { return this.unitInUse; }
        set { this.unitInUse = value; }
    }
}

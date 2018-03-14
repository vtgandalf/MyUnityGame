using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScript : MonoBehaviour {

    private Vector3 position;
    private Vector3 size;

    void Start()
    {
        size = this.GetComponent<Collider>().bounds.size;
    }
    void Update()
    {

    }
    void UpdatePosition()
    {
        this.gameObject.transform.position = this.position;
    }
    public Vector3 Size
    {
        get { return this.size; }
    }
}

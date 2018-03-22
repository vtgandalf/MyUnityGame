using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tileInfoScript : MonoBehaviour
{
    public UnitFactory factory;
    Text txt;
    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Init();
    }
    public void Init()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = factory.XZInfo();
    }
}

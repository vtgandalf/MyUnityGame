using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextScript : MonoBehaviour {
    public model hp;
    public Text text;
	// Use this for initialization
	void Start () {
        this.text.text = "HP: " + this.hp.Hp.ToString() + "%";
	}
	
	// Update is called once per frame
	void Update () {
        this.text.text = "HP: " + this.hp.Hp.ToString() + "%";
    }
}

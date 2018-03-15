using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCounterScript : MonoBehaviour {
    public PlayerManager playerManager;
    Text txt;
	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Init();
	}
    public void Init()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = (this.playerManager.CurrentPlayer+1).ToString(); 
        this.txt.color = this.playerManager.PlayerList[this.playerManager.CurrentPlayer].Color;
    }
}

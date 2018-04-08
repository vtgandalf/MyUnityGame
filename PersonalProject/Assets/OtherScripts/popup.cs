using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup : MonoBehaviour {

    public Map map;
    private Unit player;
    Text txt;
    // Use this for initialization
    void Start()
    {
        this.player = map.GetCell(map.spawnX, map.spawnY).transform.GetChild(1).GetComponent<Unit>();
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
        txt.text = player.FinishedInfo;
    }
}

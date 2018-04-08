using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Stats stats = new Stats(20,30);
    // Use this for initialization
    //void Start () {
    //	
    //}
    //
    // Update is called once per frame
    void Update () {
        int hp = stats.Health;
    	if(hp > 0)
        {
            //
        }
        else
        {
            transform.parent.GetChild(0).GetComponent<Cell>().Enemy = false;
            gameObject.SetActive(false);
        }
    }
    public string StatsInfo()
    {
        return stats.Info();
    }
    public Stats Stats
    {
        get { return this.stats; }
    }
}

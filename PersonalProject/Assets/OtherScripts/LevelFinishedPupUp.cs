using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishedPupUp : MonoBehaviour {
    public Map map;
    private Cell cell;
    private Unit player;
    private bool trigger = false;
    // Use this for initialization
    void Awake () {
        Init();
    }
	
	// Update is called once per frame
	void Update () {
        Init();
        Check();
	}
    private void Check()
    {
        if(trigger == false)
        {
            this.gameObject.SetActive(false);

        }
        else
        {
            this.gameObject.SetActive(true);
            UnityEngine.Debug.LogError("Finished!!!! | popup");
        }
    }
    private void Init()
    {
        cell = map.GetCell(map.spawnX, map.spawnY);
        if (cell != null)
        {
            UnityEngine.Debug.LogError("Tile Found");
            this.player = cell.transform.GetChild(1).GetComponent<Unit>();
            if (player != null)
            {
                UnityEngine.Debug.LogError("player found!!!! | popup");
                //trigger = player.Finished;
            }
            else
            {
                UnityEngine.Debug.LogError("player is null | popup");
            }
        }
        else
        {
            UnityEngine.Debug.LogError("cell is null | popup");
        }
    }
}

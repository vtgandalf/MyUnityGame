using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Factory : MonoBehaviour
{
    public GameObject toBeCreated;
    public int number;
    private Grid grid = new Grid();

    void Start()
    {
        SpawnObjects(number);
    }
    void Update()
    {

    }
    public void SpawnObjects(int p)
    {
        List<ID> listOfTiles = grid.ListOfTiles;
        System.Random rnd = new System.Random();
        int i = 0;
        while (i < p)
        {
            int r = rnd.Next(listOfTiles.Count);
            if (listOfTiles[r].Obj.UnitInUse == false)
            {
                float x = listOfTiles[r].Obj.transform.position.x;
                float y = listOfTiles[r].Obj.transform.localScale.y;
                float z = listOfTiles[r].Obj.transform.position.z;
                GameObject obj = Instantiate(this.toBeCreated, new Vector3(x,y/2,z), Quaternion.identity);
                i++;
            }
        }
    }
}

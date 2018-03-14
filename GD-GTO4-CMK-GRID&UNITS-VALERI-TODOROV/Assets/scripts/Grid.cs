using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int x;
    public int z;
    public TileScript tile;
    private float gX;
    private float gZ;
    private Vector3 position;
    private List<ID> listOfTiles = new List<ID>();
    public GameObject toBeCreated;
    public int numberOfObjectsToBeCreated;

    // Use this for initialization
    void Start()
    {
        GridInit();
        gX = this.gameObject.transform.position.x;
        gZ = this.gameObject.transform.position.z;
        SpawnObjects(numberOfObjectsToBeCreated);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GridInit()
    {
        ID id;
        int idCounter = 0;

        for (int i = 0; i < this.x; i++)
        {
            for (int s = 0; s < this.z; s++)
            {
                TileScript obj = Instantiate(this.tile, new Vector3(gX + i, 0,gZ + s), Quaternion.identity);
                id = new ID(idCounter,obj);
                this.listOfTiles.Add(id);
                idCounter++;
            }
        }
    }
    public List<ID> ListOfTiles
    {
        get { return this.listOfTiles; }
    }
    public int NumberOfTiles()
    {
        return x * z;
    }
    public void SpawnObjects(int p)
    {
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
                GameObject obj = Instantiate(this.toBeCreated, new Vector3(x, y / 2, z), Quaternion.identity);
                i++;
            }
        }
    }
}

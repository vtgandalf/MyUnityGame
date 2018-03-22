using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitFactory : MonoBehaviour
{
    public GameObject Prototype;
    public Map Map;


    public List<ResourceCost> Costs;

    // Temporary until we figure out a better way to decide where to spawn.
    private Vector2Int SpawnCoordinate;
    private int x = 0;
    private int z = 0;
    void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit, 100.0f))
        //    {
        //        if (hit.transform.tag == "Cell")
        //            {
        //            x = Convert.ToInt32(hit.point.x);
        //            z = Convert.ToInt32(hit.point.y);
        //            SpawnCoordinate = new Vector2Int(Convert.ToInt32(hit.point.x), Convert.ToInt32(hit.point.x));
        //            }
        //        Debug.Log(hit.collider.gameObject.name);
        //    }
        //}


        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit))
        //{
        //    x = Convert.ToInt32(Input.mousePosition.x);
        //    z = Convert.ToInt32(Input.mousePosition.y);
        //    if (hit.transform.tag == "Cell")
        //    {
        //        //x = Convert.ToInt32(hit.point.x);
        //        //z = Convert.ToInt32(hit.point.z);
        //        SpawnCoordinate = new Vector2Int(Convert.ToInt32(hit.point.x), Convert.ToInt32(hit.point.z));
        //    }
        //    Debug.Log(hit.collider.gameObject.name);
        //}
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                x = Convert.ToInt32(Input.mousePosition.x);
                z = Convert.ToInt32(Input.mousePosition.y);
                if (hit.collider.tag == "Cell")
                    Instantiate(Prototype, hit.point, Quaternion.identity);
            }
        }
    }
public string XZInfo()
{
    string info = this.x.ToString() + "," + this.z.ToString();
    return info;
}

public void SpawnUnit()
{
    bool canAfford = true;
    for (int i = 0; i < Costs.Count; i++)
    {
        if (!Costs[i].CanAfford())
        {
            canAfford = false;
        }
    }

    if (canAfford)
    {
        for (int i = 0; i < Costs.Count; i++)
        {
            Costs[i].Pay();
        }

        //Vector3 vector = new Vector3(x, 0, z);
        //Unit newUnit = Instantiate(Prototype);
        GameObject newUnit = Instantiate(Prototype);
        //GameObject newUnit = Instantiate(Prototype, vector, Quaternion.identity);
        Cell cell = Map.GetCell(SpawnCoordinate.x, SpawnCoordinate.y);

        newUnit.transform.SetParent(cell.transform, false);
    }
    else
    {
        Debug.Log("Not enough resources!");
    }
}

[System.Serializable]
public class ResourceCost
{
    public Resource Resource;
    public int Cost;

    public bool CanAfford()
    {
        return Resource.CanAfford(Cost);
    }

    public void Pay()
    {
        Resource.RemoveAmount(Cost);
    }

}
}
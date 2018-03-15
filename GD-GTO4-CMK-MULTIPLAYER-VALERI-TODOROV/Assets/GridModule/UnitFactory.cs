using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    public GameObject Prototype;
    public Map Map;


    public List<ResourceCost> Costs;
    
    // Temporary until we figure out a better way to decide where to spawn.
    private Vector2Int SpawnCoordinate;

    private void GetSpawnLocation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.GetComponent(typeof(HingeJoint)))
            {
                Debug.Log("This is a Player");
            }
            else
            {
                Debug.Log("This isn't a Player");
            }
        }
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

            Unit newUnit = Instantiate(Prototype);
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
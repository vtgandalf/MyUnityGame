using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitList : MonoBehaviour {
    private List<GameObject> unitsList = new List<GameObject>();

	public List<Unit> UnitsList
    {
        get { return this.UnitsList; }
    }

    public void AddToList(GameObject unit)
    {
        this.unitsList.Add(unit);
    }
}

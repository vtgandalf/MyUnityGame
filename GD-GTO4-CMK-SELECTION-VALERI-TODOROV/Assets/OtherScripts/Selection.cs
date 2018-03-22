using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Selection : MonoBehaviour
{

    public Map map;
    private Ray ray;
    string info = "0";
    Cell temp = new Cell();
    Cell selected = new Cell();
    void Start()
    {
        RayCasting();
    }

    void Update()
    {
        RayCasting();
    }

    public void RayCasting()
    {
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Cell cell = hit.collider.transform.parent.gameObject.GetComponent<Cell>();
            if (cell == null)
            {
                info = "not found";
            }
            else
            {
                info = cell.name;
                if (Input.GetMouseButtonDown(0) || cell == selected.transform.parent.gameObject.GetComponent<Cell>())
                {
                    this.selected = cell.transform.GetChild(0).GetComponent<Cell>();
                    this.selected.Selected();
                }
                else
                {
                    this.temp = cell;
                    this.temp.transform.GetChild(0).GetComponent<Cell>().Hovered();
                }
            }
        }
        else
        {
            info = "0";
            temp.transform.GetChild(0).GetComponent<Cell>().GetNeutral();
        }
    }
    public string Info()
    {
        return this.info;
    }
}

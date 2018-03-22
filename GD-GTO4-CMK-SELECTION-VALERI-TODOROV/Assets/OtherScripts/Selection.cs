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

                    if (this.selected != null)
                    {
                        int x = Math.Abs(cell.X - selected.transform.parent.GetComponent<Cell>().X);
                        int y = Math.Abs(cell.Y - selected.transform.parent.GetComponent<Cell>().Y);
                        info = x.ToString() + " " + y.ToString();
                        if ((x * y <= 1 && (x == 1 || y == 1)) && cell.InUse == false)
                        {
                            this.temp.transform.GetChild(0).GetComponent<Cell>().Hovered();
                            if (Input.GetMouseButtonDown(1) && this.selected != null)
                            {
                                Unit spearman = new Unit();
                                spearman = this.selected.transform.parent.GetChild(1).GetComponent<Unit>();
                                if (spearman != null)
                                {
                                    spearman.transform.SetParent(cell.transform, false);
                                    this.selected.transform.parent.GetComponent<Cell>().InUse = false;
                                    this.selected.GetNeutral();
                                    this.selected = cell;
                                    this.selected.Selected();
                                }
                            }
                        }
                        else
                        {
                            this.temp.transform.GetChild(0).GetComponent<Cell>().OutOfReach();
                        }
                    }
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

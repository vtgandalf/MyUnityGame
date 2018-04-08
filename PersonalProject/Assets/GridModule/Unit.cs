using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    //smooth movement
    private Transform target;
    public float smoothTime = 0.5F;
    private Vector3 velocity = Vector3.zero;
    private bool animationTrigger = true;

    private Cell currentPlace;
    private Cell toBeAt;
    private Cell enemyCell;
    private Map map;
    int x, y;
    Animator anim;

    //stats
    private Stats stats;
    private string finishedInfo;

    private void Start()
    {

        stats = new Stats(100,20);
        anim = GetComponent<Animator>();
        this.map = this.transform.parent.parent.GetComponent<Map>();
        Init();
    }
    private void Update()
    {
        Init();
        if (toBeAt != null)
        {

            Vector3 targetPosition = toBeAt.transform.position;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            Vector3 diff = transform.position - targetPosition;
            // we will use sqrMagnitude to avoid costly square roots
            // so if we need them to be within .01 of each other,
            // we check against .0001 (.01*.01)
            if (diff.sqrMagnitude < .0001)
            {
                ClearGrid();
                this.gameObject.transform.SetParent(toBeAt.transform, false);
                this.currentPlace = toBeAt.transform.GetChild(0).GetComponent<Cell>();
                this.currentPlace.Selected();
                Init();
                transform.position = currentPlace.transform.position;
                anim.SetTrigger("stopTransition");
            }
        }
    }
    public string FinishedInfo
    {
        get { return this.finishedInfo; }
        set { this.finishedInfo = value; }
    }
    private void Move(Cell cell)
    {
        if (cell != null)
        {
            //EnemyCheck(cell);
            if (EnemyCheck(cell) != true)
            {
                anim.SetTrigger("transition");
            }
            FinishCheck(cell);
            HealthCheck(cell);
            toBeAt = cell;
        }
    }
    private void ColourGrid()
    {
        if (currentPlace != null && map != null)
        {
            currentPlace.Selected();
            Cell a, b, c, d;
            if (y - 1 >= 0)
            {
                a = map.GetCell(x, (y - 1)).transform.GetChild(0).GetComponent<Cell>();
                TileColour(a);
            }
            if (y + 1 < map.SizeY)
            {
                b = map.GetCell(x, (y + 1)).transform.GetChild(0).GetComponent<Cell>();
                TileColour(b);
            }
            if (x - 1 >= 0)
            {
                c = map.GetCell((x - 1), y).transform.GetChild(0).GetComponent<Cell>();
                TileColour(c);
            }
            if (x + 1 < map.SizeX)
            {
                d = map.GetCell((x + 1), y).transform.GetChild(0).GetComponent<Cell>();
                TileColour(d);
            }
        }
    }
    private void ClearGrid()
    {
        if (currentPlace != null && map != null)
        {
            currentPlace.GetNeutral();
            Cell a, b, c, d;
            if (y - 1 >= 0)
            {
                a = map.GetCell(x, (y - 1)).transform.GetChild(0).GetComponent<Cell>();
                a.GetNeutral();
            }
            if (y + 1 < map.SizeY)
            {
                b = map.GetCell(x, (y + 1)).transform.GetChild(0).GetComponent<Cell>();
                b.GetNeutral();
            }
            if (x - 1 >= 0)
            {
                c = map.GetCell((x - 1), y).transform.GetChild(0).GetComponent<Cell>();
                c.GetNeutral();
            }
            if (x + 1 < map.SizeX)
            {
                d = map.GetCell((x + 1), y).transform.GetChild(0).GetComponent<Cell>();
                d.GetNeutral();
            }
        }
    }
    private void MovementCheck()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            Cell cell = map.GetCell((x - 1), y);
            Move(cell);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
            Cell cell = map.GetCell((x + 1), y);
            Move(cell);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.eulerAngles = new Vector3(0, -90, 0);
            Cell cell = map.GetCell(x, (y - 1));
            Move(cell);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.eulerAngles = new Vector3(0, 90, 0);
            Cell cell = map.GetCell(x, (y + 1));
            Move(cell);
        }
    }
    private void Init()
    {
        this.currentPlace = transform.parent.GetChild(0).GetComponent<Cell>();
        this.x = currentPlace.transform.parent.GetComponent<Cell>().X;
        this.y = currentPlace.transform.parent.GetComponent<Cell>().Y;
        ColourGrid();
        MovementCheck();
    }
    public string StatsInfo()
    {
        if (stats.Info() == "DEAD")
        {
            gameObject.SetActive(false);
        }
        return stats.Info();
    }
    public void TileColour(Cell cell)
    {
        if (cell.Enemy == true)
        {
            cell.OutOfReach();
        }
        else
        {
            cell.Hovered();
        }
    }
    public bool EnemyCheck(Cell cell)
    {

        if (cell != null)
        {
            Enemy enemy = cell.transform.GetComponentInChildren<Enemy>();
            if (enemy == null)
            {
                UnityEngine.Debug.LogError("no enemy found wtf!?");
                return false;
            }
            else
            {
                anim.SetTrigger("atack");
                UnityEngine.Debug.LogError("Enemy found");
                enemy.Stats.TakeDmg(stats.Dmg);
                stats.TakeDmg(enemy.Stats.Dmg);
                return true;
            }
        }
        else
        {
            UnityEngine.Debug.LogError("Something is deff wrong");
            return false;
        }
    }
    public void HealthCheck(Cell cell)
    {
        if (cell != null)
        {
            Health health = cell.transform.GetComponentInChildren<Health>();
            if (health == null)
            {
                UnityEngine.Debug.LogError("No health found wtf!?");
            }
            else
            {
                UnityEngine.Debug.LogError("Health found");
                anim.SetTrigger("heal");
                stats.Heal(health.Hp);
                health.gameObject.SetActive(false);
            }
        }
        else
        {
            UnityEngine.Debug.LogError("Something is deff wrong");
        }
    }
    public void FinishCheck(Cell cell)
    {
        if (cell != null)
        {
            if (cell.transform.GetChild(0).GetComponent<Cell>().Finish != true)
            {
                UnityEngine.Debug.LogError("Thats not the finish tile");
            }
            else
            {
                UnityEngine.Debug.LogError("Finished");
                FinishedInfo = "Level Completed";
            }
        }
        else
        {
            UnityEngine.Debug.LogError("Something is deff wrong");
        }
    }
}

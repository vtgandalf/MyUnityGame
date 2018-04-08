using UnityEngine;

public class Map : MonoBehaviour
{
	public int SizeX;
	public int SizeY;
    public UnitFactory factoryPlayer;
    public UnitFactory factoryEnemy;
    public UnitFactory factoryHealth;
    public int spawnX;
    public int spawnY;
    public int enemyX;
    public int enemyY;
    public int enemy1X;
    public int enemy1Y;
    public int enemy2X;
    public int enemy2Y;
    public int enemy3X;
    public int enemy3Y;
    public int healthX;
    public int healthY;
    public int health1X;
    public int health1Y;
    public int health2X;
    public int health2Y;
    public int finishX;
    public int finishY;
    //public Coordinates enemyCoordinates;
    //public Coordinates healthCoordinates;

    public float TileOffset;

	public Cell Prototype;
	
	public void Start()
	{
		Spawn();
        factoryPlayer.SpawnSingleUnit(spawnX,spawnY);
        SetFinishTile(finishX, finishY);
        spawnEnemy(enemyX,enemyY);
        spawnEnemy(enemy1X, enemy1Y);
        spawnEnemy(enemy2X, enemy2Y);
        spawnEnemy(enemy3X, enemy3Y);
        spawnHealth(healthX, healthY);
        spawnHealth(health1X, health1Y);
        spawnHealth(health2X, health2Y);
    }

	public void Spawn()
	{
		float xOffset = 0;
		for (int x = 0; x < SizeX; x++)
		{
			float yOffset = 0;
			for (int y = 0; y < SizeY; y++)
			{
				Cell newTile = Instantiate(Prototype);
                newTile.transform.SetParent(transform);
				newTile.transform.localPosition = new Vector3(xOffset, 0, yOffset);
				newTile.name = string.Format("Cell {0}x{1}", x, y);
					
				newTile.X = x;
				newTile.Y = y;
					
				yOffset += TileOffset;
			}
			xOffset += TileOffset;
		}
	}

	[ContextMenu("Test Cell 2,5")]
	public void Test()
	{
		Cell test = GetCell(2, 5);
		if (test != null)
		{
			Debug.Log(test.name, test);
		}
		else
		{
			Debug.Log("Cell 2,5 does not exist!");
		}
	}

	public Cell GetCell(int x, int y)
	{
		if (x >= SizeX || 
		    y >= SizeY ||
		    x < 0 || 
		    y < 0)
		{
			Debug.LogError("Out of bounds!");
			return null;
		}
		
		return transform.GetChild((x * SizeY)+ y).GetComponent<Cell>();	
	}
    public void spawnHealth(int x, int y)
    {
        Cell cell = GetCell(x, y);
        cell = GetCell(x, y);
        if (cell == null)
        {
            Debug.LogError("cell is null bleh");
        }
        else
        {

            factoryHealth.SpawnSingleUnit(x, y);
            Debug.LogError(cell.X.ToString() + "x" + cell.Y.ToString());
            cell.transform.GetChild(0).GetComponent<Cell>().Health = true;
        }
    }
    public void spawnEnemy(int x, int y)
    {
        Cell cell = GetCell(x, y);
        if (cell == null)
        {
            Debug.LogError("cell is null bleh");
        }
        else
        {

            factoryEnemy.SpawnSingleUnit(x, y);
            Debug.LogError(cell.X.ToString() + "x" + cell.Y.ToString()+"new enemy has been spawned");
            cell.transform.GetChild(0).GetComponent<Cell>().Enemy = true;
        }
    }
    public void SetFinishTile(int x, int y)
    {
        Cell cell = GetCell(x, y);
        cell = GetCell(x, y);
        if (cell == null)
        {
            Debug.LogError("cell is null bleh");
        }
        else
        {
            Debug.LogError(cell.X.ToString() + "x" + cell.Y.ToString()+"finishline");
            cell.transform.GetChild(0).GetComponent<Cell>().Finish = true;
        }
    }
}

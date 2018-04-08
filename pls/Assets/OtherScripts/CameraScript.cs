using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public Map map;
    private Unit player;
    private Vector3 offset;

    void Start()
    {
        this.player = map.GetCell(map.spawnX, map.spawnY).transform.GetChild(1).GetComponent<Unit>();
        if(player != null)
        {

            offset = transform.position - player.transform.position;
        }
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if(player != null)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
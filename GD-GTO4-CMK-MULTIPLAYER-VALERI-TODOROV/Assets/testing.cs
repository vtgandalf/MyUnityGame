using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour {


    Ray ray;
    RaycastHit hit;
    public GameObject prefab;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            GameObject clone = Instantiate(prefab, Vector3.Lerp(transform.position, hit.transform.position, 0.5F), hit.transform.rotation) as GameObject;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickprefab;
    Vector3 last;
    Vector3 offset; 

    private void Start()
    {
        last = transform.position;
        for(int i = 0; i < 5; i++)
        {
            GameObject bricks = Instantiate(brickprefab, last + offset, Quaternion.identity);
            last = bricks.transform.position;
            offset = new Vector3(2, 0, 0);
        }
    }
}

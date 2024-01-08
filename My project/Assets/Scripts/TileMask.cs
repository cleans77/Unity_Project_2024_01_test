using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMask : MonoBehaviour
{
    public GameObject tile;

    void Start()
    {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                Instantiate(tile, new Vector3(i, 0.0f, j), Quaternion.identity);
    }
    void Update()
    {
        
    }
}

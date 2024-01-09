using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int Hp;
    public int Mp;

    private void Start()
    {
        Hp = 100;
        Mp = 100;
    }
}

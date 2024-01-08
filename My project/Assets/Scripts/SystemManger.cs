using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SystemManger : MonoBehaviour
{
    public GameObject Player;


    private void Update()
    {
        if(Player != null)
        {
            if (Player.transform.position.y < -50.0f)
            {
                Player.transform.position = Vector3.zero + new Vector3(0.0f,1.0f,0.0f);
                Player.transform.rotation = Quaternion.identity;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        int cHp = collision.gameObject.GetComponent<PlayerCollision>().Hp;
        Debug.Log("Collision Hp : " + cHp);
    }
}

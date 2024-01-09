using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    private float CheackTime = 0.0f;
    private float Hp = 100;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("현재 남은 Hp : " + Hp);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TIME")
        {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other != null)
        {
        CheackTime += Time.deltaTime;
        if(CheackTime >= 1.0f)
        {
            Debug.Log("Hp Down");
            Hp -= 1;
            CheackTime = 0.0f;
        }
        }
    }
}

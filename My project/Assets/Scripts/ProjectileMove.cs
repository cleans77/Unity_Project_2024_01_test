using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour //�Ѿ� Ŭ���� ����
{
    public float lifeTime = 10.0f;
    public float moveSpeed = 20.0f;

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0.0f )
            Destroy(this.gameObject);
    }
}
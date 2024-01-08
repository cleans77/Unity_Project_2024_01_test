using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour //총알 클래스 설정
{
    public float lifeTime = 10.0f;
    public float moveSpeed = 20.0f;

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0.0f )
            Destroy(this.gameObject);
    }
}

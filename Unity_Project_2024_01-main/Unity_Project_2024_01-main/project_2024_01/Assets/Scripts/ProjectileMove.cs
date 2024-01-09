using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour         //총알 클래스 설정
{
    public enum PROJECTILETYPE : int
    {
        Player,
        Enemy,
    }
    public float lifeTime = 10.0f;              //총알 생성 후 살아있을 시간 ex) 10초 
    public float moveSpeed = 20.0f;             //총알 속도 설정

    private float Damage = 3f;

    public GameObject VFX_Fire_B;
    public GameObject VFX_WW_Explosion;

    public PROJECTILETYPE prjtpe = PROJECTILETYPE.Player;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy" && prjtpe == PROJECTILETYPE.Player)
        {
            Destroy(this.gameObject);
            Vector3 point = collision.ClosestPoint(transform.position);
            GameObject tempVFX = (GameObject)Instantiate(VFX_Fire_B,point,Quaternion.identity);

            collision.gameObject.GetComponent<EnemyController>().Hp -= Damage;

            if(collision.gameObject.GetComponent<EnemyController>().Hp <= 0 )
            {
                Instantiate(VFX_WW_Explosion,point,Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Player" && prjtpe == PROJECTILETYPE.Enemy)
        {
            Destroy(this.gameObject);
            Vector3 point = collision.ClosestPoint(transform.position);
            GameObject tempVFX = (GameObject)Instantiate(VFX_Fire_B, point, Quaternion.identity);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);  //총알이 Z축 앞방향으로 이동하게 

        lifeTime -= Time.deltaTime;                                         //초를 설정하여 시간 확인
        if (lifeTime < 0.0f)
        {
            Destroy(this.gameObject);                                       //오브젝트 파괴
        }
    }
}

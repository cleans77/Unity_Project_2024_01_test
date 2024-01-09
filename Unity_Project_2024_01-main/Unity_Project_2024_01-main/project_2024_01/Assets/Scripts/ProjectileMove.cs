using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour         //�Ѿ� Ŭ���� ����
{
    public enum PROJECTILETYPE : int
    {
        Player,
        Enemy,
    }
    public float lifeTime = 10.0f;              //�Ѿ� ���� �� ������� �ð� ex) 10�� 
    public float moveSpeed = 20.0f;             //�Ѿ� �ӵ� ����

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
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);  //�Ѿ��� Z�� �չ������� �̵��ϰ� 

        lifeTime -= Time.deltaTime;                                         //�ʸ� �����Ͽ� �ð� Ȯ��
        if (lifeTime < 0.0f)
        {
            Destroy(this.gameObject);                                       //������Ʈ �ı�
        }
    }
}

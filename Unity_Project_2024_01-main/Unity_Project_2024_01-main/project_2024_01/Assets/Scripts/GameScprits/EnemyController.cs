using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 8.0f;          //�̵� �ӵ�
    public float rotationSpeed = 1.0f;      //��ž ȸ�� �ӵ�
    public GameObject projectile;           //�Ѿ� ������ 
    public GameObject Pivot;
    public Transform firePoint;             //�Ѿ� �߻� ��ġ
    public float fireRate = 1.0f;           //�Ѿ� �߻� �ӵ� 

    private Rigidbody body;
    private Transform player;
    private float nextFireTime;

    public float Hp = 100;
    void Start()
    {
        body = GetComponent<Rigidbody>();       //���� ������Ʈ�� RigidBody�� ������
        player = GameObject.FindGameObjectWithTag("Player").transform;      //Player Tag�� ������ �ִ� ������Ʈ tranform�� �Է�
    }   
    void Update()
    {
        if(player != null)      //Player �� ������ �� ������Ʈ ���� ����ؼ� ����
        {
            if (Vector3.Distance(player.position, transform.position) > 5.0f) //Vector3.Distance ����Ƽ���� �����ϴ� �Ÿ� ��� �Լ� 
            {
                Vector3 direction = (player.position - transform.position).normalized; //�̵� ���⼺ (�÷��̾�� �� ������Ʈ(��))
                body.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime); //���⼺ ���Ȱ��� �ݿ�
            }
            //��ž ȸ�� �ҽ� �ڵ� 
            Vector3 targetDirection = (player.position - Pivot.transform.position).normalized;  //��ž�� ���⼺ ���
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            //���� ȸ������ �ݿ�
            Pivot.transform.rotation = Quaternion.Lerp(Pivot.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); 

            //�Ѿ� �߻�

            if(Time.time > nextFireTime) 
            {
                nextFireTime = Time.time + 1f / fireRate;       //�ð���� ��� Ƚ�� 
                GameObject temp = (GameObject)Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
                temp.GetComponent<ProjectileMove>().prjtpe = ProjectileMove.PROJECTILETYPE.Enemy;
            }
        }
    }
}
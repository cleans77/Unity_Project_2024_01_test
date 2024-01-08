using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemController : MonoBehaviour
{
    public float Speed = 7.5f;          //�̵��ӵ�
    public float rotationSpeed = 1.0f;  //��ž ȸ�� �ӵ�
    public GameObject projectile;       //�Ѿ� ������
    public GameObject pivot;
    public Transform firePoint;         //�Ѿ� �߻� ��ġ
    public float fireRate = 1.0f;       //�Ѿ� �߻� �ӵ�

    private Rigidbody Rigidbody;
    private Transform player;
    private float nextFireTime;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if(player != null)
        {
            if(Vector3.Distance(player.position,transform.position) > 5.0f)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                Rigidbody.MovePosition(transform.position + direction * Speed * Time.deltaTime);
            }
            Vector3 targetDirection = (player.position - pivot.transform.position).normalized;//��ž�� ���⼺ ���
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            //���� ȸ������ �ݿ�
            pivot.transform.rotation = Quaternion.Lerp(pivot.transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);
        }
        if(Time.time > nextFireTime)
        {
            nextFireTime = Time.deltaTime + 1f / fireRate;
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}

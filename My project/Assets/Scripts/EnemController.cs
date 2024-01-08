using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemController : MonoBehaviour
{
    public float Speed = 7.5f;          //이동속도
    public float rotationSpeed = 1.0f;  //포탑 회전 속도
    public GameObject projectile;       //총알 프리팹
    public GameObject pivot;
    public Transform firePoint;         //총알 발사 위치
    public float fireRate = 1.0f;       //총알 발사 속도

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
            Vector3 targetDirection = (player.position - pivot.transform.position).normalized;//포탑의 방향성 계산
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            //계산된 회전값을 반영
            pivot.transform.rotation = Quaternion.Lerp(pivot.transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);
        }
        if(Time.time > nextFireTime)
        {
            nextFireTime = Time.deltaTime + 1f / fireRate;
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}

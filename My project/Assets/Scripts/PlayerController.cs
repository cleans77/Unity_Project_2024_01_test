using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public GameObject pivot;
    public Camera viewCamera; //main Camera Object
    public Vector3 velocity;
    public Rigidbody body;
    void Start()
    {
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;
        //화면에서 -> 게임 3D 공간 좌표를 변환해서 Vector3에 넣는다.
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,viewCamera.transform.position.y));

        Vector3 targetPos = new Vector3(mousePos.x,pivot.transform.position.y,mousePos.z);

        pivot.transform.LookAt(targetPos, Vector3.up);
    }
    private void FixedUpdate()
    {
        body.MovePosition(body.position + velocity * Time.fixedDeltaTime);
    }
}

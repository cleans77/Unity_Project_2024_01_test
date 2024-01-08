using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public GameObject pivot;
    public Camera viewCamera; //main Camera Object
    public Vector3 velocity;
    void Start()
    {
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //ȭ�鿡�� -> ���� 3D ���� ��ǥ�� ��ȯ�ؼ� Vector3�� �ִ´�.
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,viewCamera.transform.position.y));

        Vector3 targetPos = new Vector3(mousePos.x,pivot.transform.position.y,mousePos.z);

        pivot.transform.LookAt(targetPos, Vector3.up);
    }
}

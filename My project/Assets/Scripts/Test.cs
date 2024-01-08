using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    public float Hp;
    private float Speed = 1f;
    public Vector3 pos = Vector3.zero;  //Vector3 변수 선언 float
    void Start()
    {
        Hp = 30;
        pos = new Vector3(1,1,1);
        transform.position = pos;
    }
    void Update()
    {
        moveCube();

        if (Input.GetKeyDown(KeyCode.E))
            Speed += 1f;
    }
    private void moveCube()
    {
        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += Move;
        //if (Input.GetKey(KeyCode.UpArrow))
        //    transform.position += new Vector3(0.0f,Speed, 0.0f);
        //if (Input.GetKey(KeyCode.DownArrow))
        //    transform.position += new Vector3(0.0f,-Speed, 0.0f);
        //if (Input.GetKey(KeyCode.RightArrow))
        //    transform.position += new Vector3(Speed,0.0f, 0.0f);
        //if (Input.GetKey(KeyCode.LeftArrow))
        //    transform.position += new Vector3(-Speed,0.0f, 0.0f);
    }
}

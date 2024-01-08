using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GenMangera : MonoBehaviour
{
    public Camera viewCamera;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,viewCamera.transform.position.y));

        GameObject temp = (GameObject)Instantiate(Enemy , mousePos,Quaternion.identity);

    }
}

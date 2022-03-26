using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    // public GameObject child;
    //public Transform parent;

    public GameObject camera1;
    public GameObject camera2;

    public void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    public void Update()
    {
        //if (Input.GetButtonDown("RightBumper"))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }

        //if (Input.GetButtonDown("LeftBumper"))
        if (Input.GetKeyDown(KeyCode.C))

        {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
    }
}
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
        if (Input.GetButtonDown("RightBumper"))
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }

        if (Input.GetButtonDown("LeftBumper"))
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
    }
}
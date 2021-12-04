using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    public float speed = 20;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("LeftJoyX");
        float moveVertical = Input.GetAxis("LeftJoyY");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        Debug.Log(movement);
        rb.AddForce(movement * speed);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Accumulate : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0.8f, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(-0.8f, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0.0f, 0f, -0.8f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(0.0f, 0f, 0.8f);
            }
        }
    }
}
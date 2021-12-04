using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightcolor : MonoBehaviour
{
    public Light robolight;

    // Start is called before the first frame update
    private void Start()
    {
        robolight.enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnMouseUp()
    {
        robolight.color = Color.green;
    }

    private void OnMouseDown()
    {
        robolight.color = Color.cyan;

        Debug.Log("colour changed");
    }
}
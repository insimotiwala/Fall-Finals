using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eastlightcolour : MonoBehaviour
{
    public Light l1;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("East"))
        {
            l1.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
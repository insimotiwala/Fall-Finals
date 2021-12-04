using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    public GameObject text;
    public Light mylight;

    // Start is called before the first frame update
    private void Start()
    {
        text.SetActive(false);
        mylight.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnMouseOver()
    {
        text.SetActive(true);
        Debug.Log("Its Working!!!");
        mylight.enabled = true;
    }

    public void OnMouseExit()
    {
        // _callout.SetActive(false);
        Debug.Log("not hovering");
        text.SetActive(false);
        mylight.enabled = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDnew : MonoBehaviour
{
    private testmover _testmove;

    // Start is called before the first frame update
    private void Start()
    {
        _testmove = transform.GetComponentInParent<testmover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (!_testmove._reachedTarget) { return; }
        GameObject go = other.gameObject;
        if (go.tag != "Roll") { return; }
        _testmove.StartReconfigure(go);
    }
}
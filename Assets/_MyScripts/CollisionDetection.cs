using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private MobileUnit _mobileUnit;

    // Start is called before the first frame update
    private void Start()
    {
        _mobileUnit = transform.GetComponentInParent<MobileUnit>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (_mobileUnit == null)
        {
            return;
        }
        if (!_mobileUnit._reachedTarget)
        { return; }
        GameObject go = other.gameObject;
        if (go.tag != "Agent") { return; }
        //_mobileUnit.StartConfigure(go);
    }
}
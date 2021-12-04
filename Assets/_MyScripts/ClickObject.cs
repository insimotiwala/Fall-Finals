using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickObject : MonoBehaviour
{
    public GameObject reachehere;
    private NavMeshAgent robo;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            robo = GetComponent<NavMeshAgent>();
            robo.SetDestination(reachehere.transform.position);
            Debug.Log("Clicked on the Robot!");
        }
        else
        { return; }
    }
}
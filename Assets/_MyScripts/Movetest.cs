using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movetest : MonoBehaviour
{
    public GameObject Target;

    private NavMeshAgent Agent;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void OnMouseUp()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.SetDestination(Target.transform.position);
    }

    private void OnMouseDown()
    {
        Debug.Log("FINALLY");
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
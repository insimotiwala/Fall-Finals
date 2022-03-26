using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class joystick_declump : MonoBehaviour
{
   private NavMeshAgent agent2;
    public GameObject center;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
       
           agent2 = this.GetComponent<NavMeshAgent>();
            agent2.SetDestination(center.transform.position);
            GetComponent<Rotate>();
        }
    }

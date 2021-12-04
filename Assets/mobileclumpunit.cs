using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class mobileclumpunit : MonoBehaviour
{
    public GameObject Target;
    public GameObject[] Positions;
    private NavMeshAgent Agent;
    public GameObject Factory; //Factory Prefab To Instantiate
    public GameObject ClumpMesh;
    public Dictionary<GameObject, GameObject> Configure = new Dictionary<GameObject, GameObject>();
    // public float speed;

    [HideInInspector]
    public bool _reachedTarget = false;

    // Start is called before the first frame update
    private void Start()
    {
        Agent = this.GetComponent<NavMeshAgent>();
        Agent.SetDestination(Target.transform.position);
        foreach (GameObject pos in Positions)
        {
            Configure.Add(pos, null);
        }
    }

    public void StartConfigure(GameObject go)
    {
        Debug.Log("StartConfigure");
        List<GameObject> keys = Configure.Keys.ToList();
        foreach (GameObject key in keys)
        {
            //Guard Statement
            if (Configure[key] != null) { continue; } //Go To The Next Loop Iteration
            Configure[key] = go;
            go.GetComponentInParent<NavMeshAgent>().enabled = false;
            go.GetComponentInParent<MobileUnit>().enabled = false;
            go.GetComponent<CollisionDetection>().enabled = false;
            break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (_reachedTarget)
        {
            bool allConfig = true;
            foreach (KeyValuePair<GameObject, GameObject> kvp in Configure)
            {
                //Guard Statement
                if (kvp.Value == null) { allConfig = false; continue; }
                if (kvp.Key.transform.position == kvp.Value.transform.position) { continue; }

                //Move Object Into Position
                GameObject cAgent = kvp.Value;
                Vector3 pos = kvp.Key.transform.position;
                Quaternion rot = kvp.Key.transform.rotation;
                Debug.Log(pos);
                cAgent.transform.position = Vector3.Lerp(cAgent.transform.position, pos, Time.deltaTime);
                cAgent.transform.rotation = Quaternion.Lerp(cAgent.transform.rotation, rot, Time.deltaTime);
                if (Vector3.Distance(cAgent.transform.position, pos) < 0.05f)
                {
                    cAgent.transform.position = pos;
                    cAgent.transform.rotation = rot;
                    //TODO: set parent
                }
                allConfig = false;
            }

            if (allConfig)
            {
                List<GameObject> keys = Configure.Keys.ToList();
                foreach (GameObject key in keys)
                {
                    GameObject go = Configure[key];
                    //Destroy(go);
                }

                //GameObject factory = Instantiate(Factory, transform.position, transform.rotation);
                //float moveY = factory.transform.localScale.y / 2; //Get Half Factory Height
                //factory.transform.position += new Vector3(0, moveY, 0); //Move Factory Up
                //Destroy(gameObject);
            }

            return;
        }

        Debug.DrawLine(this.transform.position, Target.transform.position, Color.black);
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.red);

        //Test If Agent Has Reached Target
        if (!Agent.pathPending) //If Agent Is Looking For Target It Hasn't Reached Target
        {
            if (Agent.remainingDistance <= Agent.stoppingDistance) //Agent Is As Close As It Can Get
            {
                if (!Agent.hasPath || Agent.velocity.sqrMagnitude == 0f) //If Agent Isn't Moving
                {
                    Debug.Log("Target Reached!!!");
                    _reachedTarget = true;
                    Agent.enabled = false;
                    GameObject keys = Configure.Keys.ToList()[0];
                    Configure[keys] = ClumpMesh;
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class testmover : MonoBehaviour
{
    private NavMeshAgent robopart;
    public GameObject Clump;

    public GameObject destination;
    public GameObject[] Randompos;
    public Dictionary<GameObject, GameObject> Reconfigure = new Dictionary<GameObject, GameObject>();

    [HideInInspector]
    public bool _reachedTarget = false;

    // Start is called before the first frame update
    private void Start()
    {
        robopart = this.GetComponent<NavMeshAgent>();
        robopart.SetDestination(destination.transform.position);
        Randompos = Shuffle(Randompos);
        foreach (GameObject pos in Randompos)
        {
            Debug.Log("1");
            float x = Random.Range(0, 0.01f);
            float y = Random.Range(0, 0.01f);
            float z = Random.Range(0, 0.01f);
            pos.transform.localPosition = new Vector3(x, y, z); //need to define these values
            Reconfigure.Add(pos, null);
        }
    }

    private GameObject[] Shuffle(GameObject[] objects)
    {
        GameObject tempGO;
        for (int i = 0; i < objects.Length; i++)
        {
            //Debug.Log("i: " + i);
            int rnd = Random.Range(0, objects.Length);
            tempGO = objects[rnd];
            objects[rnd] = objects[i];
            objects[i] = tempGO;
        }
        return objects;
    }

    public void StartReconfigure(GameObject go)
    {
        Debug.Log("StartReconfigure");
        List<GameObject> keys = Reconfigure.Keys.ToList();
        foreach (GameObject key in keys)
        {
            //Guard Statement
            if (Reconfigure[key] != null) { continue; } //Go To The Next Loop Iteration
            Reconfigure[key] = go;
            go.GetComponentInParent<NavMeshAgent>().enabled = false;
            go.GetComponentInParent<testmover>().enabled = false;
            go.GetComponent<CollisionDetection>().enabled = false;

            break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        {
            if (_reachedTarget)
            {
                bool allConfig = true;
                foreach (KeyValuePair<GameObject, GameObject> kvp in Reconfigure)
                {
                    //Guard Statement
                    if (kvp.Value == null) { allConfig = false; continue; }
                    if (kvp.Key.transform.position == kvp.Value.transform.position) { continue; }

                    //Move Object Into Position
                    GameObject cAgent = kvp.Value;
                    Vector3 pos = kvp.Key.transform.position;
                    Quaternion rot = kvp.Key.transform.rotation;
                    cAgent.transform.position = Vector3.Lerp(cAgent.transform.position, pos, Time.deltaTime);
                    cAgent.transform.rotation = Quaternion.Lerp(cAgent.transform.rotation, rot, Time.deltaTime);
                    if (Vector3.Distance(cAgent.transform.position, pos) < 0.05f)
                    {
                        cAgent.transform.position = pos;
                        cAgent.transform.rotation = rot;
                    }
                    allConfig = false;
                }

                if (allConfig)
                {
                    List<GameObject> keys = Reconfigure.Keys.ToList();
                    foreach (GameObject key in keys)
                    {
                        GameObject go = Reconfigure[key];
                    }
                }

                return;
            }

            Debug.DrawLine(this.transform.position, destination.transform.position, Color.black);
            Debug.DrawRay(this.transform.position, this.transform.forward, Color.red);

            //Test If Agent Has Reached Target
            if (!robopart.pathPending) //If Agent Is Looking For Target It Hasn't Reached Target
            {
                if (robopart.remainingDistance <= robopart.stoppingDistance) //Agent Is As Close As It Can Get
                {
                    if (!robopart.hasPath || robopart.velocity.sqrMagnitude == 0f) //If Agent Isn't Moving
                    {
                        Debug.Log("Target Reached!!!");
                        _reachedTarget = true;
                        robopart.enabled = false;
                        GameObject keys = Reconfigure.Keys.ToList()[0];
                        Reconfigure[keys] = Clump;
                    }
                }
            }
        }
    }
}
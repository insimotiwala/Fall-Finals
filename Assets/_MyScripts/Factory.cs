using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject Prefab;
    public string TargetTag;
    public int MakeLimit = 10; //maximum agents before destruction
    private int _makeCount = 0; //each time we make an agent, add to count
    private GameObject Target;

    public float MakeRate = 2.0f;

    private float _lastMake = 0;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(TargetTag);
        Target = targets[Random.Range(0, targets.Length)];
    }

    // Update is called once per frame
    private void Update()
    {
        //guard statement
        if (Target == null) { return; }

        //destroy factory when limit reached
        if (_makeCount >= MakeLimit)
        {
            Destroy(gameObject);
        }

        _lastMake += Time.deltaTime; //_lastMake = _lastMake + Time.deltaTime;
        if (_lastMake > MakeRate)
        {
            //Debug.Log("Make");
            _lastMake = 0; //reset time counter
            _makeCount++; //increase agent make count by one
            GameObject go = Instantiate(Prefab, this.transform.position, Quaternion.identity);
            MobileUnit mu = go.GetComponent<MobileUnit>();
            if (mu == null) { Debug.Log("mu"); }
            mu.Target = Target;
        }
    }
}
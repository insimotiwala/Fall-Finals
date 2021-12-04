using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robotmovecurosor : MonoBehaviour
{
    //global variables
    public float Speed2 = 10.0f;

    public LayerMask SelectedMask;
    public LayerMask PlacedMask;
    private RectTransform rect2;

    // Start is called before the first frame update
    private void Start()
    {
        rect2 = GetComponent<RectTransform>();
    }

    private bool _isRelocating2 = false;
    private GameObject _robo;

    // Update is called once per frame
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(rect2.position);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.black);

        RaycastHit hit;
        if (_isRelocating2)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, PlacedMask))
            {
                float yy = _robo.transform.localScale.y / 2.0f;
                _robo.transform.position = hit.point + new Vector3(0, yy, 0);
                if (Input.GetButtonDown("South"))
                {
                    testmover testmove01 = _robo.GetComponent<testmover>();
                    testmove01.enabled = true;
                    _isRelocating2 = false;
                }
            }
        }
        else
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, SelectedMask))
            {
                Debug.Log("RoboSelected");
                if (Input.GetButtonDown("South"))
                {
                    _robo = hit.transform.gameObject;
                    testmover testmove01 = _robo.GetComponent<testmover>();
                    testmove01.enabled = false;
                    _isRelocating2 = true;
                }
            }
        }

        //get input
        Vector2 joy = new Vector2(Input.GetAxis("RightJoyX"), -Input.GetAxis("RightJoyY"));
        if (joy.magnitude < 0.3f) { return; }
        joy.Normalize();

        //local variables
        float width = Screen.width;
        float height = Screen.height;
        float multiplier = Speed2 * Time.deltaTime;
        Vector2 anchor = rect2.anchoredPosition;

        //update values
        float x = anchor.x + joy.x * multiplier;
        x = Mathf.Clamp(x, -width / 2, width / 2);
        float y = anchor.y + joy.y * multiplier;
        y = Mathf.Clamp(y, -height / 2, height / 2);

        //set anchor
        anchor = new Vector2(x, y);
        rect2.anchoredPosition = anchor;
    }
}
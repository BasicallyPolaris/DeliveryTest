using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform body;

    private RaycastHit hit;
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            body.position = hit.point;
    }
    }
}

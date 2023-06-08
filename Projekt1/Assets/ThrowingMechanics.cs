using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingMechanics : MonoBehaviour
{
    public Vector2 minPower;
    public Vector2 maxPower;
    public float forceMultiplier;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {

    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos-mousePressDownPos);
    }


    private void Shoot(Vector3 Force)
    {
        if(isShoot)    
            return;

        rb.AddForce(new Vector3(Force.x,-Force.y,Force.y) * forceMultiplier);
        isShoot = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingUI : MonoBehaviour
{

    private Rigidbody2D rb;

    // Speed at which the object rotates.
    private float rotationSpeed = 1.0f;

    //Gets multiplied to the force applied to the object to shoot it left or right.
    private float directionModifier;

    private Vector2 shootforce = new Vector2(100.0f, 200.0f);

    /**
     * Disables gravity and sets variables used for gravity simulation.
     */
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.gravityScale = 35.0f;
        directionModifier = -1.0f;
    }

    // Rotates the object.
    void Update()
    {
        rb.MoveRotation(rb.rotation + rotationSpeed);
        if (Input.GetKey(KeyCode.Space)) {
            FallDown();
        }
    }


    /**
     * Activates gravity on the object and drops it down.
     * Pushes it a little bit in another direction beforehand.
     */
    public void FallDown() {
        rb.isKinematic = false;
        rb.AddForce(new Vector2(shootforce.x * directionModifier, - shootforce.y) 
            * rb.mass * rb.gravityScale);
        directionModifier *= -1.0f;
    }
}
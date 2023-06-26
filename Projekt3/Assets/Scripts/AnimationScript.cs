using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator animator;
    private Vector3 priorPosition;
    private Vector3 currentPosition;

    private bool positionChanged;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        priorPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        updateWalking();


    }

    private void updateWalking()
    {
        if (rb.velocity.Equals(new Vector3(0f, 0f, 0f)))
        {
            animator.SetBool("isWalking", false);
        } else {
            animator.SetBool("isWalking", true);
        }
    }
}

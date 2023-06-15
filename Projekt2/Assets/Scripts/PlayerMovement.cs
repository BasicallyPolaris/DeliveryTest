using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    // Walking related
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]

    // Jumping and gravity related
    private float jumpForce;
    private bool isGrounded;
    [SerializeField]
    private float gravity;

    // Used for movement
    private Vector3 moveDirection;
    private Vector3 velocity;
    
    // Used for scene components
    private CharacterController controller;
    private Animator animator;

    /**
     * Used to get the CharacterController component
     */
    void Start() {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }   

    /**
     * Used to move the player
     */
    void Update() {
        Move();
    } 

    /**
     * Used to move the player
     */
    private void Move() {
        isGrounded = controller.isGrounded; 

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        if (isGrounded) {
            Movement();
        }

        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    /**
     * Used to move the player
     */
    private void Movement() {
        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) 
        {
            Walk();
        } 
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) 
        {
            Run();
        } 
        else 
        {
            Idle();
        }

        moveDirection *= moveSpeed;

        if (Input.GetButtonDown("Jump")) 
        {
            Jump();
        }

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    /**
     * Used for idle animation and movement
     */
    private void Idle() {
        moveSpeed = 0f;
        animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    /**
     * Used for walk animation and movement
     */
    private void Walk() {
        moveSpeed = walkSpeed;
        animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    /**
     * Used for run animation and movement
     */
    private void Run() {
        moveSpeed = runSpeed;
        animator.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }
    
    /**
     * Used for jump animation and movement
     */
    private void Jump() {
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
    }
}
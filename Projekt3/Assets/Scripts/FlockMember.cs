using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlockMember : MonoBehaviour
{
    private NavMeshAgent agent;

    private GameObject turtle;

    public FlockState currentState = FlockState.SEEK;

    private float viewDistance = 25f; 
    public FlockManager manager;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        turtle = agent.gameObject;
        seekFlock();
    }

    // Update is called once per frame
    void Update()
    {
        updateState();
        planMovement();
        
    }

    public void checkAttack() {
        
    } 
    private void seekFlock() {
        agent.SetDestination(manager.averagePosition);
    }

    private void seekTarget() {
        agent.SetDestination(manager.target.position);
    }

    private void flee() {
        agent.SetDestination(manager.safeSpot.position);
    }

    private void updateState() {
        if (currentState == FlockState.SEEK && manager.checkFlock(turtle, viewDistance))
        {
            currentState = FlockState.FLOCK;
        } else if (currentState == FlockState.FLOCK && manager.checkAttack())
        {
            currentState = FlockState.FLEE;
        } else if (currentState == FlockState.FLEE && !manager.checkAttack())
        {
            currentState = FlockState.FLOCK;
        }
    }
    private void planMovement() {
            switch (currentState)
            {
                case FlockState.SEEK:
                    seekFlock();
                    break;
                case FlockState.FLOCK:
                    seekTarget();
                    break;
                default:
                    flee();
                    break;
            }
        }
}

public enum FlockState
{
    SEEK,
    FLOCK,
    FLEE
}

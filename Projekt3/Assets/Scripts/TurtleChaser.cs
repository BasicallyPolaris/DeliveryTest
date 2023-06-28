using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurtleChaser : Seeker.TargetSeeker
{
    public FlockManager manager;

    private GameObject turtle;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        turtle = agent.gameObject;
        target = manager.getNearestNeighbour(turtle).transform;
    }
        // Update is called once per frame
    void Update()
    {
        if (manager.isNearestEnemy(turtle))
        {
            target = manager.getNearestNeighbour(turtle).transform;
            updateSearchState();
        } else {
            wander();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Seeker
    {
    public class TargetSeeker : MonoBehaviour
    {
        public Transform target;

        public Vector3 currentDestination;

        private float senseRadius = 50f;

        private float viewRadius = 15f;

        private Ray searchRay;
        private RaycastHit hit;
        protected NavMeshAgent agent;

        public SearchState currentSearchState;

        private float distanceToTarget;
        private Vector3 baseVelocity;

        // Start is called before the first frame update
        public void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            currentSearchState = SearchState.WANDER;
            baseVelocity = agent.velocity;
            wander();
            
        }

        // Update is called once per frame
        void Update()
        {
            updateSearchState();
        }

        protected void updateSearchState() {
            //Only update if agent is near its destination
            distanceToTarget = Vector3.Distance(target.position, agent.transform.position);
            if (agent.remainingDistance < agent.stoppingDistance) {
                if (distanceToTarget < senseRadius) {
                    if (distanceToTarget < viewRadius)
                    {
                        currentSearchState = SearchState.HUNT;
                    } else {
                        currentSearchState = SearchState.SEEK;
                    }
                } else {
                    currentSearchState = SearchState.WANDER;
                }
                planMovement();
            }
            
        }

        private void planMovement() {
            switch (currentSearchState)
            {
                case SearchState.HUNT:
                    hunt();
                    break;
                case SearchState.SEEK:
                    seek();
                    break;
                default:
                    wander();
                    break;
            }
        }

        protected void wander() {
            float targetX = Random.Range(-10f, 10f);
            float targetY = Random.Range(-10f, 10f);
            Vector3 targetOffset = new Vector3(targetX, 0f, targetY);
            currentDestination = agent.transform.position + targetOffset;
            agent.SetDestination(currentDestination);
        }

        private void seek() {
            float targetRadius = Random.Range(0f, senseRadius);
            float angle = Random.Range(0f, Mathf.PI);
            Vector3 targetOffset = new Vector3(targetRadius * Mathf.Cos(angle), 0f, targetRadius * Mathf.Sin(angle));
            currentDestination = target.position + targetOffset;
            agent.SetDestination(currentDestination);
        }

        private void hunt() {
            currentDestination = target.position;
            agent.SetDestination(currentDestination);
        }
    }

    public enum SearchState {
        SEEK,
        HUNT,
        WANDER
    }
}

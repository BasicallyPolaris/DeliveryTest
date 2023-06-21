using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Seeker
    {
    public class TargetSeeker : MonoBehaviour
    {
        public Transform target;

        private float senseRadius = 150000f;
        private Ray searchRay;
        private RaycastHit hit;
        private NavMeshAgent agent;

        private SearchState currentSearchState;
        private Vector3 baseVelocity;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            currentSearchState = SearchState.WANDER;
            baseVelocity = agent.velocity;
            
        }

        // Update is called once per frame
        void Update()
        {
            updateSearchState();
            planMovement();
        }

        private void updateSearchState() {
            if (Vector3.Distance(transform.position, target.position) < senseRadius) {
                sendSearchRay();
            } else {
                currentSearchState = SearchState.WANDER;
            }
        }

        private void sendSearchRay() {
            searchRay = new Ray(transform.position, transform.position - target.position);
            if (Physics.Raycast(searchRay, out hit, senseRadius)) {
                if (hit.transform == target) {
                    currentSearchState = SearchState.HUNT;
                    return;
                }
            }
            currentSearchState = SearchState.SEEK;
        }

        private void planMovement() {
            switch (currentSearchState)
            {

                case SearchState.HUNT:
                    agent.SetDestination(target.position);
                    break;
                case SearchState.SEEK:
                    agent.velocity = 2f * baseVelocity;
                    agent.SetDestination(target.position);
                    break;
                default:
                    agent.velocity = baseVelocity;
                    break;
            }
        }
    }

    public enum SearchState {
        SEEK,
        HUNT,
        WANDER
    }
}

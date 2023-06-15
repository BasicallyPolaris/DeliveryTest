using UnityEngine;
using UnityEngine.Animations.Rigging;

public class FeetAligner : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private LayerMask layerMask; // Select all layers that foot placement applies to.

    [SerializeField][Range (0, 1f)]
    private float DistanceToGround; // Distance from where the foot transform is to the lowest possible position of the foot.

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {


    }

    private void OnAnimatorIK() {

        if (animator) { // Only carry out the following code if there is an Animator set.

            // Set the weights of left and right feet to the current value defined by the curve in our animations.
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1f);
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1f);

            // Left Foot
            RaycastHit hit;
            // We cast our ray from above the foot in case the current terrain/floor is above the foot position.
            Ray ray = new Ray(animator.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, DistanceToGround + 1.5f, layerMask)) {

                // We're only concerned with objects that are tagged as "Walkable"

                    Vector3 footPosition = hit.point; // The target foot position is where the raycast hit a walkable object...
                    footPosition.y += DistanceToGround; // ... taking account the distance to the ground we added above.
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, footPosition);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward, hit.normal));


            }

            // Right Foot
            ray = new Ray(animator.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, DistanceToGround + 1.5f, layerMask)) {

                    Vector3 footPosition = hit.point;
                    footPosition.y += DistanceToGround;
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, footPosition);
                    animator.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(transform.forward, hit.normal));


            }


        }

    }

}
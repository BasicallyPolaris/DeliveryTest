using UnityEngine;

public class FeetAligner : MonoBehaviour
{
    [Range(0, 1f)]
    public float ikWeight = 1f; // Blend between animation and IK placement.

    public LayerMask groundMask; // Layer mask for the ground.

    public float footPlacementOffset = 0.1f; // Offset for the foot placement.

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK()
    {
        if (animator)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, ikWeight);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, ikWeight);

            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, ikWeight);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, ikWeight);

            Vector3 rayDir = Vector3.down;

            AdjustFootIK(AvatarIKGoal.LeftFoot, rayDir);
            AdjustFootIK(AvatarIKGoal.RightFoot, rayDir);
        }
    }

    private void AdjustFootIK(AvatarIKGoal ikGoal, Vector3 rayDir)
    {
        Vector3 rayStartPos = animator.GetIKPosition(ikGoal) + Vector3.up;
        bool isGround = Physics.Raycast(rayStartPos, rayDir, out RaycastHit hitInfo, 2f, groundMask);

        if (isGround)
        {
            Vector3 hitPos = hitInfo.point;
            hitPos += hitInfo.normal * footPlacementOffset;
            animator.SetIKPosition(ikGoal, hitPos);

            Quaternion lookDir = Quaternion.LookRotation(transform.forward, hitInfo.normal);
            animator.SetIKRotation(ikGoal, lookDir);
        }
    }
}
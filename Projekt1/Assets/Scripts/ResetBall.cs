using UnityEngine;

public class ResetBall : MonoBehaviour
{
    [SerializeField]
    private ThrowingMechanics throwingMechanics;

    public void ResetBallClick(Collider other)
    {
        throwingMechanics.resetBall();
    }
}
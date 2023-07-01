using UnityEngine;

/**
 * This Class is used for the UI-Button to reset the ball.
 */
public class ResetBall : MonoBehaviour
{
    [SerializeField]
    private ThrowingMechanics throwingMechanics;

    /**
     * Used to reset the ball if he leaves the playing field or hits a cup.
     */
    public void ResetBallClick(Collider other)
    {
        throwingMechanics.resetBall();
    }
}
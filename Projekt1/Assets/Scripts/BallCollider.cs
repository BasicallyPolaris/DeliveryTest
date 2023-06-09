using UnityEngine;

public class BallCollider : MonoBehaviour {
    
    /**
     * Used to reset the ball if he leaves the playing field
     */  
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Ball") {
            other.gameObject.GetComponent<ThrowingMechanics>().resetBall();
        }
    }
}
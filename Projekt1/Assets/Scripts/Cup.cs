using UnityEngine;
public class Cup : MonoBehaviour
{

    // Used to detect the ball in the cup
    private Collider ballCollider;
    private GameObject gameLogic;

    void Start() {
        ballCollider = GetComponent<Collider>();
        gameLogic = GameObject.Find("GameLogic");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Debug.Log("Ball in cup");
            other.gameObject.GetComponent<ThrowingMechanics>().resetBall();
            gameLogic.GetComponent<GameLogic>().increseScore++;
            gameObject.SetActive(false);
        }
    }
}
using UnityEngine;
public class Cup : MonoBehaviour
{

    // Used to detect the ball in the cup
    private Collider ballCollider;
    private GameObject gameLogic;
    private float dissipateState = 0f;

    /**
     * Start is called before the first frame update.
     * Used to get the collider of the ball and the game logic.
     */
    void Start() {
        ballCollider = GetComponent<CapsuleCollider>();
        gameLogic = GameObject.Find("GameLogic");
    }

    /**
     * Update is called once per frame.
     * Used to increase the dissipation of the cup if the ball the cup before.
     */
    void Update() {
        if (ballCollider.enabled == false && dissipateState < 1f) {
            dissipateState += 0.01f;
            GetComponent<Renderer>().material.SetFloat("_Dissipate_State", dissipateState);
        }   
    }

    /**
     * Used to detect if the ball is in the cup.
     * If the ball is in the cup, the ball will be reset and the score will be increased.
     */
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<ThrowingMechanics>().resetBall();
            gameLogic.GetComponent<GameLogic>().increseScore();
            GetComponent<Collider>().enabled = false;
            ballCollider.enabled = false;
        }
    }
}
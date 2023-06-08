using UnityEngine;
public class Cup : MonoBehaviour
{

    // Used to detect the ball in the cup
    private Collider ballCollider;
    private GameObject gameLogic;
    private float dissipateState = 0f;

    void Start() {
        ballCollider = GetComponent<Collider>();
        gameLogic = GameObject.Find("GameLogic");
    }

    void Update() {
        if (ballCollider.enabled == false && dissipateState < 1f) {
            dissipateState += 0.01f;
            GetComponent<Renderer>().material.SetFloat("_Dissipate_State", dissipateState);
        }   
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<ThrowingMechanics>().resetBall();
            gameLogic.GetComponent<GameLogic>().increseScore();
            GetComponent<Collider>().enabled = false;
        }
    }
}
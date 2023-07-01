using UnityEngine;

public class ThrowingMechanics : MonoBehaviour
{
    private const float DISSIPATE_SPEED = 2f;
    private GameObject gameLogic;
    public Vector2 minPower;
    public Vector2 maxPower;
    public float forceMultiplier;

    private Vector3 startPos;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    // Rigidbody used for the object that is thrown
    private Rigidbody rb;
    private bool wasShot;
    private float resetting;
    private float dissipateState;

    private float collided;
    private bool respawning;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        resetting = 0f;
        dissipateState = 0f;
        collided = 0f;
        wasShot = false;
        respawning = false;
        startPos = transform.position;
        gameLogic = GameObject.Find("GameLogic");
    }

    /**
     * Gets called once a frame.
     * Used to check if the ball is reseting OR collided with the table. Depending on the state it manages the dissipation/reset state of the ball.
     */
    void Update()
    {
        if (collided >= 4f && resetting < 1f) {
            resetting += Time.deltaTime;
            return;
        }

        if (collided >= 4f && resetting >= 1f) {
            collided = 0;
            resetBall();
        }

        if (resetting >= 1f && dissipateState < 1f) {
            dissipateState += DISSIPATE_SPEED * Time.deltaTime;
            GetComponent<Renderer>().material.SetFloat("_Dissipate_State", dissipateState);
        } 

        if (resetting >= 1f && dissipateState >= 1) {
            resetting = 0f;
            transform.position = startPos;
            wasShot = false;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            respawning = true;
        }

        if (respawning && dissipateState > 0) {
            dissipateState = dissipateState - DISSIPATE_SPEED * Time.deltaTime > 0 ? dissipateState - DISSIPATE_SPEED * Time.deltaTime : 0;
            GetComponent<Renderer>().material.SetFloat("_Dissipate_State", dissipateState);

            if (dissipateState == 0) 
                respawning = false;
        }
    }

    /**
     * Used to detect if the ball is colliding with the table. If so, start dissipating the ball after 1 second.
     */
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Table") {
            collided++;
        }
    }

    /**
     * Used to detect if the ball is colliding with the table. If so, start dissipating the ball after 1 second.
     */
    void OnCollisionStay(Collision other) {
        if (other.gameObject.tag == "Table") {
            collided++;
        }
    }

    /**
     * Used to detect if the played clicked on the ball, store the current mouse position for force calculation.
     */
    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    /**
     * Used to detect if the player released the mouse button, calculate the force and shoot the ball.
     */
    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos - mousePressDownPos);
    }

    /**
     * Used to shoot the ball with the given force. 
     * If the ball was already shot befure resetting at current state, it wont be shot again.
     */
    private void Shoot(Vector3 Force)
    {
        if(wasShot) return;

        rb.useGravity = true;
        rb.AddForce(new Vector3(Force.x,-Force.y,Force.y) * forceMultiplier);
        wasShot = true;
        gameLogic.GetComponent<GameLogic>().increaseTries();
    }

    /**
     * Resets the ball to it's initial starting position by slowly making it dissipate and reappear.
     */
    public void resetBall()
    {
        collided = 0f;
        respawning = false;
        resetting = 1f;
    }
}

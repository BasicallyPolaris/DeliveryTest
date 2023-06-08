using UnityEngine;

public class ThrowingMechanics : MonoBehaviour
{
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
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        startPos = transform.position;
        gameLogic = GameObject.Find("GameLogic");
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {

    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos-mousePressDownPos);
    }

    private void Shoot(Vector3 Force)
    {
        if(wasShot) return;

        rb.useGravity = true;
        rb.AddForce(new Vector3(Force.x,-Force.y,Force.y) * forceMultiplier);
        wasShot = true;
        gameLogic.GetComponent<GameLogic>().increaseTries();
    }

    public void resetBall()
    {
        wasShot = false;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPos;
    }
}

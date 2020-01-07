using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public GameObject hand;

    const string prefix = "pokemonball_";

    GameObject ball = null;
    int ballIndex = -1;

    public float handPower;

    public bool inHands = false;
    //Vector3 originalBallPos;
    Collider ballCol;
    Rigidbody ballRb;
    Camera cam;

    public bool focusOnBall = false;

    // Start is called before the first frame update
    void Start()
    {
        //originalBallPos = ball.transform.position;
        //ballCol = ball.GetComponent<SphereCollider>();
        //ballRb = ball.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!inHands)
            {
                if (focusOnBall)
                {
                    Debug.Log("Grab Ball!");
                    ball.transform.SetParent(hand.transform);
                    ball.transform.localPosition = new Vector3(0, -0.4f, 0);
                    inHands = true;
                    focusOnBall = false;
                    ballCol.isTrigger = true;
                    ballRb.useGravity = false;
                    ballRb.velocity = Vector3.zero;
                    ballRb.angularVelocity = Vector3.zero;
                    ball.transform.rotation = Quaternion.identity;
                }
            }
            else
            {
                ball.transform.SetParent(null);
                //ball.transform.localPosition = originalBallPos;
                inHands = false;
                ballCol.isTrigger = false;
                ballRb.useGravity = true;
                ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
                ballRb.angularVelocity = cam.transform.rotation * Vector3.forward * handPower;
            }
        }
    }

    public void setFocusOnBall(int focusBallIndex)
    {
        if (!inHands)
        {
            focusOnBall = true;
            ballIndex = focusBallIndex;
            ball = GameObject.Find(prefix + ballIndex.ToString());
            ballCol = ball.GetComponent<SphereCollider>();
            ballRb = ball.GetComponent<Rigidbody>();
        }
    }

    public void setFocusNotOnBall()
    {
        if (!inHands)
        {
            focusOnBall = false;
            ballIndex = -1;
        }
    }
}

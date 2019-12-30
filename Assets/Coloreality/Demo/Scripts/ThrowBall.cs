using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coloreality;

public class ThrowBall : MonoBehaviour
{
    public GameObject handBall;
    public GameObject handLeft;
    public float handPower;
    public Camera cam;
    Collider ballCol;
    Rigidbody ballRb;

    public bool inHandLeft;

    // Start is called before the first frame update
    void Start()
    {
        ballCol = handBall.GetComponent<CapsuleCollider>();
        ballRb = handBall.GetComponent<Rigidbody>();
        Debug.Log("throwball started");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1!!!!!!!!");
            if (inHandLeft)//ball is in hand, throw it!
            {
                handBall.transform.SetParent(null);
                //ball.transform.localPosition = originalBallPos;
                inHandLeft = false;
                handLeft.GetComponent<LeapSingleHandView>().hasHandBall = false;
                ballCol.isTrigger = false;
                ballRb.useGravity = true;
                ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
                ballRb.angularVelocity = cam.transform.rotation * Vector3.forward * handPower;
            }
            else//ball is out of hand, take it back;
            {
                handBall.transform.SetParent(handLeft.transform);
                handBall.transform.localPosition = new Vector3(0, 0, 0);
                inHandLeft = true;
                handLeft.GetComponent<LeapSingleHandView>().hasHandBall = true;
                ballCol.isTrigger = true;
                ballRb.useGravity = false;
                ballRb.velocity = Vector3.zero;
                ballRb.angularVelocity = Vector3.zero;
                handBall.transform.rotation = Quaternion.identity;
            }
        }
    }
}

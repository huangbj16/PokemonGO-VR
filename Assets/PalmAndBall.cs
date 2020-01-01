using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coloreality.LeapWrapper;

public class PalmAndBall : MonoBehaviour
{
    public GameObject pokeBall;
    public GameObject handRight;
    public GameObject palm;
    public float handPower;
    public Camera cam;

    bool hasBall;
    float pinchDistance;
    Rigidbody ballRb;
    Collider ballCol;

    // Start is called before the first frame update
    void Start()
    {
        hasBall = false;
        pinchDistance = 100;
        ballRb = pokeBall.GetComponent<Rigidbody>();
        ballCol = pokeBall.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void refresh(LeapHand hand)
    {
        pinchDistance = hand.PinchDistance;
        Debug.Log("pinch distance = " + pinchDistance);
        if(!hasBall && pinchDistance < 10)//grab
        {
            Debug.Log("grab");
            hasBall = true;
            pokeBall.transform.SetParent(palm.transform);
            pokeBall.transform.localPosition = Vector3.zero;
            pokeBall.transform.rotation = Quaternion.identity;
            ballCol.isTrigger = true;
            ballRb.useGravity = false;
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
        }
        else if(hasBall && pinchDistance > 80)//release
        {
            Debug.Log("release");
            hasBall = false;
            pokeBall.transform.SetParent(null);
            pokeBall.transform.localScale = new Vector3(1, 1, 1);
            ballCol.isTrigger = false;
            ballRb.useGravity = true;
            ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
            ballRb.angularVelocity = cam.transform.rotation * Vector3.forward * handPower;
        }
    }
}

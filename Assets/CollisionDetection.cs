using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    /*
    public Camera cam;
    public float handPower;
    */

    public GameObject parentObj;
    public GameObject pokeBall;
    public GameObject normalBall;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision! name: " + collision.gameObject.name);
        if (collision.gameObject.name == "PokeBall")
        {
            GameObject pokeBall = collision.gameObject;
            Rigidbody ballRb = pokeBall.GetComponent<Rigidbody>();
            ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
        }
    }
    */

    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter: " + other.name);
        if (other.name == "PokeBall")
        {
            pokeBall.transform.SetParent(parentObj.transform);
            pokeBall.transform.localPosition = new Vector3(0, 0, 0);
            pokeBall.transform.rotation = Quaternion.identity;
        }
        else if(other.name == "NormalBall")
        {
            normalBall.transform.SetParent(parentObj.transform);
            normalBall.transform.localPosition = new Vector3(0, 0, 0);
            normalBall.transform.rotation = Quaternion.identity;
        }
    }
    */
}

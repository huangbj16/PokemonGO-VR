using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Rigidbody boundingBox;
    // Start is called before the first frame update
    void Start()
    {
        boundingBox = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        boundingBox.velocity = Vector3.zero;
    }
}

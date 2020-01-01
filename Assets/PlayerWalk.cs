using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public int playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bool canWalk = !this.GetComponent<PlayerGrab>().inHands;
        if (Input.GetButton("Fire1"))
            transform.position += Camera.main.transform.forward * playerSpeed * Time.deltaTime;
    }
}

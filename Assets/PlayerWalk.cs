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
        // FIXME: modify here to allow vertical moving.
        bool canWalk = !this.GetComponent<PlayerGrab>().inHands;
        if (Input.GetButton("Fire1") && canWalk)
        {
            Vector3 shift = Camera.main.transform.forward;
            Vector3 step = new Vector3(shift[0], 0.0f, shift[2]);
            transform.position += step * playerSpeed * Time.deltaTime;
        }
    }
}

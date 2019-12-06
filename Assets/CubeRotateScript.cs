using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotateScript : MonoBehaviour
{
    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float x;
    // Update is called once per frame
    void Update()
    {
        transform = GetComponent<Transform>();
        x += Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(x, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonBattle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide!");
        if(Caught())
        {
            Debug.Log("Caught!");
        }
    }

    private bool Caught()
    {
        // FIXME: Always true now.
        float t = Random.value;
        return t < 2.0f;
    }
}

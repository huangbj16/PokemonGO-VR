using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PokemonBattle : MonoBehaviour
{
    public GameObject result;
    public GameObject ball;
    private bool caught;
    public int aliveFrame = 300;
    private int curFrame;
    //public GameObject ball;
    public GameObject effect;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        curFrame = 0;
        caught = false;
        Vector3 effectPos = gameObject.GetComponent<Transform>().position + new Vector3(0, 1.0f, 0);
        Quaternion effectQuat = effect.GetComponent<Transform>().rotation;
        effect.GetComponent<Transform>().SetPositionAndRotation(effectPos, effectQuat);
        effect.SetActive(false);
        result.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("pokemonball"))
        {
            UnityEngine.Debug.Log("Collide!");
            if (Caught())
            {
                UnityEngine.Debug.Log("Caught!");
                result.SetActive(true);
                effect.SetActive(true);
                gameObject.SetActive(false);
                counterAfterCollision cAC = manager.GetComponent<counterAfterCollision>();
                cAC.startCounter();
            }
        }
    }

    private bool Caught()
    {
        // FIXME: Always true now.
        float t = Random.value;
        return t < 2.0f;
    }
}

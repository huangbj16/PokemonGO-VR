using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PokemonBattle : MonoBehaviour
{
    public GameObject result;
    public GameObject ball;
    //public GameObject ball;
    public GameObject effect;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 effectPos = gameObject.GetComponent<Transform>().position + new Vector3(0, 0.0f, 0.0f);
        Vector3 resultPos = gameObject.GetComponent<Transform>().position + new Vector3(0, 3.0f, 0.0f);
        Quaternion effectQuat = effect.GetComponent<Transform>().rotation;
        Quaternion resultQuat = result.GetComponent<Transform>().rotation;
        effect.GetComponent<Transform>().SetPositionAndRotation(effectPos, effectQuat);
        result.GetComponent<Transform>().SetPositionAndRotation(resultPos, resultQuat);
        effect.SetActive(false);
        result.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
                Renderer[] rd = GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rd)
                {
                    r.enabled = false;
                }
                UnityEngine.Debug.Log("hide");
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

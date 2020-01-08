using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class counterAfterCollision : MonoBehaviour
{
    Stopwatch counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = new Stopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter.ElapsedMilliseconds > 3000)
        {
            //left to do disconnect()
            SceneManager.LoadScene("MainScene");
        }
    }

    public void startCounter()
    {
        counter.Start();
    }
}

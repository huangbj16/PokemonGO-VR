using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuManager;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onGazeButtonEnter()
    {
        Debug.Log("Game" + name);
        menuManager.GetComponent<MenuController>().gazing = true;
        menuManager.GetComponent<MenuController>().lastGameBtn = name;
    }

    public void onGazeButtonExit()
    {
        menuManager.GetComponent<MenuController>().gazing = false;
    }

    public void turnWhite() {
        // GetComponent<Renderer>().material.color = Color.white;
    }

    public void turnRed() {
    }

    public void turnBlue() {
        // GetComponent<Renderer>().material.color = Color.blue;
    }
}

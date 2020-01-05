﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onGazeEnter()
    {
        Debug.Log("Gaze enter");
        turnBlue();
    }

    public void onCardboardClick()
    {
        Debug.Log("Cardboard Click!");
    }

    public void turnWhite() {
        GetComponent<Renderer>().material.color = Color.white;
    }

    public void turnRed() {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void turnBlue() {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public bool gazing = false;
    public string lastGameBtn = "";
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gazing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && gazing)
        {
            Debug.Log("Click Fire1");
            if (lastGameBtn.Contains("Back"))
            {
                SceneManager.LoadScene("MainScene");
            }
            else if(lastGameBtn.Contains("Battle"))
            {
                player.GetComponent<PlayerGrab>().curMode = "Battle";
            }
            else if (lastGameBtn.Contains("Catch"))
            {
                player.GetComponent<PlayerGrab>().curMode = "Catch";
            }
        }
    }

    public void setGazing(bool flag)
    {
        gazing = flag;
        player.GetComponent<PlayerGrab>().gazing = flag;
    }

}

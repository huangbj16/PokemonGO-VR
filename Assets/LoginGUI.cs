using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginGUI : MonoBehaviour
{
    public string sceneName;

    string inputIp = "";
    string inputPort = "";
    bool showGUI = true;
    int portResult;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("UseIp"))
        {
            inputIp = PlayerPrefs.GetString("UseIp");
        }
        else
        {
            inputIp = "127.0.0.1";
        }

        if (PlayerPrefs.HasKey("UsePort"))
        {
            inputPort = PlayerPrefs.GetInt("UsePort").ToString();
        }
        else
        {
            inputPort = "2333";
        }
    }

    Rect rectGUI = new Rect(100, 10, 400, 265);

    private void GUIWindow(int id)
    {
        GUI.skin.box.fontSize = 20;
        GUI.skin.textField.fontSize = 20;
        GUI.skin.label.fontSize = 20;
        GUI.Label(new Rect(10, 25, 50, 30), "IP:");
        inputIp = GUI.TextField(new Rect(90, 25, 300, 30), inputIp);
        GUI.Label(new Rect(10, 65, 50, 30), "Port:");
        inputPort = GUI.TextField(new Rect(90, 65, 300, 30), inputPort);
        if (GUI.Button(new Rect(10, 105, 380, 40), "Connect"))
        {
            PassingParameters.serverIPAddress = inputIp;
            if (int.TryParse(inputPort, out portResult))
            {
                PassingParameters.serverIPPort = portResult;
            }
            Debug.Log(PassingParameters.serverIPAddress + " " + PassingParameters.serverIPPort);
            SceneManager.LoadScene(sceneName);
        }
    }

    void OnGUI()
    {
        if (showGUI)
        {
            GUI.Window(0, rectGUI, GUIWindow, "Coloreality");
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("UseIp", inputIp);
        PlayerPrefs.SetInt("UsePort", portResult);
        PlayerPrefs.Save();
    }
}

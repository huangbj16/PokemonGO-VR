using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    public Text ipAddressField;
    public string sceneName;

    public void login()
    {
        Debug.Log("confirm!");
        string ipAddress = ipAddressField.text;
        PassingParameters.serverIPAddress = ipAddress;
        SceneManager.LoadScene(sceneName);
    }
}

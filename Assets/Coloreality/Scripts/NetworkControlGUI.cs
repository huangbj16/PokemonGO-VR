using UnityEngine;
using System.Collections;

namespace Coloreality
{
	public class NetworkControlGUI : MonoBehaviour {
		ColorealityManager cManager;

		string inputIp = "";
		string inputPort = "";

		bool showGUI = false;

		void Start () {
			infoStyle.alignment = TextAnchor.MiddleCenter;
	        infoStyle.normal.textColor = Color.white;

			cManager = GetComponent<ColorealityManager>();
            /*
			if (PlayerPrefs.HasKey("UseIp")) {
				inputIp = PlayerPrefs.GetString("UseIp");
			} else {
				inputIp = cManager.network.Ip;
			}
            */

            if (PassingParameters.serverIPAddress != "" && PassingParameters.serverIPAddress != null)
            {
                Debug.Log("success: server IP Address is: ///" + PassingParameters.serverIPAddress+"///");
                inputIp = PassingParameters.serverIPAddress;
            }
            else
            {
                Debug.Log("error: server IP Address is not input");
                inputIp = "127.0.0.1";//by default
            }

            /*
            if (PlayerPrefs.HasKey("UsePort")) {
				inputPort = PlayerPrefs.GetInt("UsePort").ToString();
			} else {
				inputPort = cManager.network.Port.ToString();
			}
            */

            if (PassingParameters.serverIPPort != -1)
            {
                Debug.Log("success: server IP Port is: ///" + PassingParameters.serverIPPort + "///");
                inputPort = PassingParameters.serverIPPort.ToString();
            }
            else
            {
                Debug.Log("error: server IP Port is not input");
                inputPort = "2333";//by default
            }

            cManager.network.OnConnected += (object sender, System.EventArgs e) => {
				cManager.info += "\r\nConnected!";
                Debug.Log("Connected");
				//showGUI = true;
			};
			cManager.network.OnDisconnected += (object sender, System.EventArgs e) => {
                cManager.info += "\r\nDisconnected.";
                Debug.Log("Disconnected");
                //showGUI = true;
            };
			cManager.network.OnError += (object sender, ErrorEventArgs e) => cManager.info += "\r\nError: " + e.Message;
            int portResult;
            if (int.TryParse(inputPort, out portResult))
            {
                cManager.TryConnect(inputIp, portResult);
            }
            else
            {
                cManager.info = "Port is not in right format.";
            }
        }
		
		// string info = "Please enter the server's IP and Port, then click [Connect].";

		Rect rectGUI = new Rect (100, 10, 400, 265);
	    GUIStyle infoStyle = new GUIStyle();

		private void GUIWindow(int id){
			GUI.skin.box.fontSize = 20;
			GUI.skin.textField.fontSize = 20;
			GUI.skin.label.fontSize = 20;
			GUI.Label(new Rect(10, 25, 50, 30), "IP:");
			inputIp = GUI.TextField(new Rect(90, 25, 300, 30), inputIp);
			GUI.Label(new Rect(10, 65, 50, 30), "Port:");
			inputPort = GUI.TextField(new Rect(90, 65, 300, 30), inputPort);
			if(GUI.Button(new Rect (10, 105, 380, 40), "Connect")) {
				int portResult;
				if (int.TryParse (inputPort, out portResult)) {
					cManager.TryConnect(inputIp, portResult);
				} else {
                    cManager.info = "Port is not in right format.";
				}
			}

			if(cManager.info.Length > 6000) cManager.info = cManager.info.Substring(cManager.info.Length - 6000);
	        GUI.TextArea(new Rect (10, 155, 380, 100), cManager.info, infoStyle);

		}

		void OnGUI(){
            //Debug.Log("OnGUI: showGUI = " + showGUI);
			if (showGUI) 
			{
				GUI.Window(0, rectGUI, GUIWindow, "Coloreality");
			}
		}

		void OnApplicationQuit(){
			PlayerPrefs.SetString("UseIp", inputIp);
			PlayerPrefs.SetInt("UsePort", cManager.network.Port);
			PlayerPrefs.Save();
		}
	}

}
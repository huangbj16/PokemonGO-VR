using System.Collections.Generic;
using UnityEngine;

namespace Coloreality
{
	public class DemoSwitcher : MonoBehaviour {

		public ColorealityManager cManager;

		public GameObject[] objs;
		public int curIndex = 0;
        public bool isSwitchable;

		void Start(){
			cManager = ColorealityManager.Instance;
			if(cManager == null)
			{
				Debug.LogError("Cannot find ColorealityManager Instance.");
				enabled = false;
			}

			OpenObject(curIndex);
		}

		public void OpenObject(int index){
			if (curIndex < 0 && curIndex >= objs.Length)
				return;
				
			for (int i = 0; i < objs.Length; i++) {
				objs[i].SetActive(index == i);
			}
		}

		void Update () {
            if (isSwitchable)
            {
                if (cManager.network.IsConnected && Input.GetMouseButtonDown(0))
                {
                    curIndex = (++curIndex >= objs.Length ? 0 : curIndex);
                    OpenObject(curIndex);
                }
            }
		}

	}
}
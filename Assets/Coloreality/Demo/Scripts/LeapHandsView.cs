﻿using UnityEngine;
using System.Collections.Generic;
using Coloreality.LeapWrapper;
using Coloreality.LeapWrapper.Receiver;

namespace Coloreality
{
	public class LeapHandsView : MonoBehaviour {
		ColorealityManager cManager;

        public GameObject self;
		public GameObject handLeft;
		public GameObject handRight;
        public GameObject superArm;

		LeapSingleHandView[] handViews;
        PalmAndBall palmAndBall;

		float lastUpdateTime = 0;
		float cancelInterval = 0.5f;

		void Start () {
			cManager = ColorealityManager.Instance;
            if(cManager == null)
            {
                Debug.LogError("Cannot find ColorealityManager Instance.");
                enabled = false;
            }

            handViews = new LeapSingleHandView[2];
			handViews[0] = handLeft.GetComponent<LeapSingleHandView>();
            handViews[1] = handRight.GetComponent<LeapSingleHandView>();
            palmAndBall = self.GetComponent<PalmAndBall>();
            superArm.SetActive(false);
		}
		
		void FixedUpdate () {
            bool[] hasHandSide = new bool[2] { false, false };
			if (cManager.Leap.Data != null) {
				List<LeapHand> hands = cManager.Leap.Data.frame.Hands;
                if (hands.Count > 0)
                {
                    Vector position = hands[0].PalmPosition;
                    //cManager.info += position.x + " " + position.y + " " + position.z;
                }
                for (int i = 0; i < hands.Count; i++) {
					int curSide = hands [i].IsLeft ? 0 : 1;
					hasHandSide[curSide] = true;
					handViews[curSide].UpdateHand(hands[i]);

                    if (hands[i].IsRight)
                    {
                        palmAndBall.refresh(hands[i]);
                    }
                    /*
                    if (hands[i].IsRight)
                    {
                        //superArm Test
                        //Quaternion armRotation = hands[i].Arm.Rotation.ToQuaternion();
                        superArm.transform.localPosition = hands[i].Fingers[1].TipPosition.ToScaledVector3();
                        Debug.Log("pinch distance = " + hands[i].PinchDistance);
                    }
                    */
                }


				for (int side = 0; side < 2; side++) {
                    handViews[side].gameObject.SetActive (hasHandSide[side]);
                    //handViews[side].gameObject.SetActive(false);
                }
				lastUpdateTime = Time.time;
			} else  if(Time.time - lastUpdateTime > cancelInterval) {
				for (int side = 0; side < 2; side++) {
					handViews[side].gameObject.SetActive(false);
				}
			}
		}

	}
}

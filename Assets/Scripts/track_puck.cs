using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track_puck : MonoBehaviour
{
	public float offsetX, offsetY, offsetZ, yPosOffset;

	public SteamVR_TrackedObject controller;

	public bool isActivated{ get; set; }

	public Light cubeLight;

	private ushort collisionTimer;

	// Use this for initialization
	void Start () {
		cubeLight.enabled = true;
		collisionTimer = 0;
		isActivated = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (controller.transform.position.x, controller.transform.position.y + yPosOffset, controller.transform.position.z);
		transform.eulerAngles = new Vector3 (controller.transform.eulerAngles.x, controller.transform.eulerAngles.y, controller.transform.eulerAngles.z);
		transform.Rotate (new Vector3(offsetX, offsetY, offsetZ));
	}

	void OnTriggerEnter (Collider other) {
		collisionTimer = 700;
		SteamVR_Controller.Input((int) controller.index).TriggerHapticPulse(3999, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
		if (other.gameObject.CompareTag ("ActivateTrigger")) {
			Activate ();
		} else if (other.gameObject.CompareTag ("MazeWall") || other.gameObject.CompareTag("Gate")) {
			deActivate ();
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.CompareTag ("MazeWall") || other.gameObject.CompareTag ("Gate")) {
			if (collisionTimer < 3000) {
				collisionTimer++;
				SteamVR_Controller.Input((int) controller.index).TriggerHapticPulse(2000, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (collisionTimer > 1000) {
			deActivate ();
		}
		collisionTimer = 0;
		SteamVR_Controller.Input((int) controller.index).TriggerHapticPulse(3999, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
	}

	void deActivate ()
	{
		SteamVR_Controller.Input((int) controller.index).TriggerHapticPulse(3999, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
		isActivated = false;
		//Renderer rend = GetComponent<Renderer> ();
		//rend.material.SetColor ("_Color", Color.black);
		SteamVR_Controller.Input((int) controller.index).TriggerHapticPulse(3999, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
		if (cubeLight != null) {
			cubeLight.enabled = isActivated;
		}

	}

	void Activate () {
		isActivated = true;
		//Renderer rend = GetComponent<Renderer> ();
		//rend.material.SetColor ("_Color", Color.green);
		cubeLight.enabled = isActivated;
	}
}

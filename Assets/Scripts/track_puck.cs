using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track_puck : MonoBehaviour
{
	public float offsetX, offsetY, offsetZ, yPosOffset;

	public SteamVR_TrackedObject controller;

	private bool isActive;

	public Light cubeLight;

	private ushort collisionTimer;

	// Use this for initialization
	void Start ()
	{
		collisionTimer = 0;
		isActive = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (gameObject.CompareTag ("wall")) {
			transform.position = new Vector3 (controller.transform.position.x, controller.transform.position.y + yPosOffset, transform.position.z);
			transform.eulerAngles = new Vector3 (controller.transform.eulerAngles.x, controller.transform.eulerAngles.y, controller.transform.eulerAngles.z);
			transform.Rotate (new Vector3(offsetX, offsetY, offsetZ));
		} else if (gameObject.CompareTag ("floor")) {
			transform.position = new Vector3 (controller.transform.position.x, transform.position.y + yPosOffset, controller.transform.position.z);
			transform.eulerAngles = new Vector3 (controller.transform.eulerAngles.x, controller.transform.eulerAngles.y, controller.transform.eulerAngles.z);
			transform.Rotate (new Vector3(offsetX, offsetY, offsetZ));
		} else if (gameObject.CompareTag ("inPlace")) {
			transform.position = new Vector3 (controller.transform.position.x, controller.transform.position.y + yPosOffset, controller.transform.position.z);
			transform.eulerAngles = new Vector3 (controller.transform.eulerAngles.x, controller.transform.eulerAngles.y, controller.transform.eulerAngles.z);
			transform.Rotate (new Vector3(offsetX, offsetY, offsetZ));
		} 
			
	}

	void OnTriggerEnter (Collider other)
	{
		deActivate ();
		collisionTimer = 0;
		//SteamVR_Controller.Input((int) controller.index).TriggerHapticPulse(3999, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
		if (other.gameObject.CompareTag ("ActivateTrigger")) {
			Activate ();
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.CompareTag ("MazeWall") || other.gameObject.CompareTag ("Gate")) {
			if (collisionTimer < 4000) {
				collisionTimer++;
				//SteamVR_Controller.Input((int) controller.index).TriggerHapticPulse(2000, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (collisionTimer > 500) {
			deActivate ();
		}
		collisionTimer = 0;
		//SteamVR_Controller.Input((int) controller.index).TriggerHapticPulse(3999, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
	}

	void deActivate ()
	{
		//SteamVR_Controller.Input((int) controller.index).TriggerHapticPulse(3999, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
		isActive = false;
		Renderer rend = GetComponent<Renderer> ();
		rend.material.SetColor ("_Color", Color.black);
		//SteamVR_Controller.Input((int) controller.index).TriggerHapticPulse(3999, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
		cubeLight.enabled = false;


	}

	void Activate ()
	{
		isActive = true;
		Renderer rend = GetComponent<Renderer> ();
		rend.material.SetColor ("_Color", Color.green);
		cubeLight.enabled = isActive;
	}
}

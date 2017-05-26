using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track_puck : MonoBehaviour
{
	public float offsetX, offsetY, offsetZ;

	public SteamVR_TrackedObject controller;

	private bool isActive;

	// Use this for initialization
	void Start ()
	{
		isActive = true;

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (gameObject.CompareTag ("wall")) {
			transform.position = new Vector3 (controller.transform.position.x, controller.transform.position.y, transform.position.z);
			transform.eulerAngles = new Vector3 (controller.transform.eulerAngles.x, controller.transform.eulerAngles.y, controller.transform.eulerAngles.z);
			transform.Rotate (new Vector3(offsetX, offsetY, offsetZ));
		} else if (gameObject.CompareTag ("floor")) {
			transform.position = new Vector3 (controller.transform.position.x, transform.position.y, controller.transform.position.z);
			transform.eulerAngles = new Vector3 (controller.transform.eulerAngles.x, controller.transform.eulerAngles.y, controller.transform.eulerAngles.z);
			transform.Rotate (new Vector3(offsetX, offsetY, offsetZ));
		} else if (gameObject.CompareTag ("inPlace")) {
			transform.position = new Vector3 (controller.transform.position.x, controller.transform.position.y, controller.transform.position.z);
			transform.eulerAngles = new Vector3 (controller.transform.eulerAngles.x, controller.transform.eulerAngles.y, controller.transform.eulerAngles.z);
			transform.Rotate (new Vector3(offsetX, offsetY, offsetZ));
		}
			
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("MazeWall")) {
			deActivate ();

		} else if (other.gameObject.CompareTag ("ActivateTrigger")) {
			Activate ();
		}

	}

	void deActivate ()
	{
		isActive = false;
		Renderer rend = GetComponent<Renderer> ();
		rend.material.SetColor ("_Color", Color.black);
	}

	void Activate ()
	{
		isActive = true;
		Renderer rend = GetComponent<Renderer> ();
		rend.material.SetColor ("_Color", Color.green);
	}
}

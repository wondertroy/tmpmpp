using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FIXME: compress code into one script
//TODO: look into adding sfx when colliding
public class track_puck_floor : MonoBehaviour
{

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
		transform.position = new Vector3 (controller.transform.position.x, transform.position.y, controller.transform.position.z);
		transform.rotation = controller.transform.rotation;
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
		//TODO: change cube scale when colliding
	}

	void Activate ()
	{
		isActive = true;
		Renderer rend = GetComponent<Renderer> ();
		rend.material.SetColor ("_Color", Color.green);
		//TODO: revert cube scale when colliding
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate_trigger : MonoBehaviour {

	public bool correctlyActivated{ get; set;}

	// Use this for initialization
	void Start ()
	{
		correctlyActivated = false;

	}

	void OnTriggerEnter (Collider other) {
		if (gameObject.CompareTag (other.gameObject.tag)) {
			Debug.Log ("trigger activated " + gameObject.tag);
			correctlyActivated = true;
		}
	}

	void OnTriggerExit (Collider other) {
		correctlyActivated = false;
	}


}

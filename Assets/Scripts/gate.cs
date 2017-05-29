using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour {

	public gate_trigger left;

	public gate_trigger right;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (left.correctlyActivated && right.correctlyActivated) {
			Disable ();
		}
	}


	void Disable () {
		Debug.Log ("gate disabled", gameObject);
		gameObject.SetActive (false);
	}
}

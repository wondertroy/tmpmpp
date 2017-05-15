using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_trigger : MonoBehaviour {

	public int playerNo;
	private Color triggerColour { get; set; }

	public void Start() {
		Renderer rend = GetComponent<Renderer> ();
		switch (playerNo) {
			case 1:
				rend.material.SetColor ("_Color", Color.green);
				break;
			case 2:
				rend.material.SetColor ("_Color", Color.blue);
				break;
			default:
				rend.material.SetColor ("_Color", Color.green);
				break;
		}
	}
}

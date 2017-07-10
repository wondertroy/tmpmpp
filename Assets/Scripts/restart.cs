using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour {

	public GameObject gate1;

	public GameObject gate2;

	public GameObject gate3;


		void Update() {
			if (Input.GetKeyDown ("space"))
				gate1.SetActive (true);
				gate2.SetActive (true);
			    gate3.SetActive (true);

		}
	}


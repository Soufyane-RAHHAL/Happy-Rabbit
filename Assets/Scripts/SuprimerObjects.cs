using UnityEngine;
using System.Collections;

public class SuprimerObjects : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Collector") {			
			target.gameObject.SetActive (false);
		}
	}
}

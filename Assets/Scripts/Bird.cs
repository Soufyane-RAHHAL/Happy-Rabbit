using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	private bool itsforthesecondTime=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 temp = transform.position;
		temp.x += 0.08f;
		transform.position = temp;
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Border") {
			Destroy (gameObject);
		}
	}
}

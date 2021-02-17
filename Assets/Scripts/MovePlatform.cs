using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {
	private float width,height;
	private int direction=-1;
	// Use this for initialization
	void Start () {
		height =   Camera.main.orthographicSize ;
		width = height * Screen.width / Screen.height;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 temp = transform.position;
			temp.x += 0.05f*direction;
		if (temp.x >= width) {
			direction = -1;
		}if (temp.x <= -width)
			direction = 1;

		transform.position = temp;
	}
}

using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	private  float offsetY;
	private float height , width;
	private float speed=0.02f;
	public static CameraMove instance;
	// Use this for initialization
	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
	public float getSpeed(){
		return speed;
	}
	void Start () {
		height = Camera.main.orthographicSize * 2f;
		width = height * Screen.width / Screen.height;
		offsetY = width/4;
		StartCoroutine (Speed ());

	}

	// Update is called once per frame
	void Update () {
//		if (PlayerScipt.instance != null) {
		if (playerScripts.instance.getcaMove ()) {
			MoveThecamera ();
		}
//
//		}
	}
	void MoveThecamera(){
		Vector3 temp = transform.position;
		temp.y -=speed;
		transform.position = temp;
	}
	IEnumerator Speed(){
		yield return new WaitForSeconds (12f);
		speed += 0.01f/2;
		Debug.Log (speed);
		StartCoroutine (Speed ());
	}
}

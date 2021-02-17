using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour {
	private float width, height;
	[SerializeField]
	private GameObject Birdobj;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateBirds",0f,Random.Range(0f,3f));
		height =   Camera.main.orthographicSize ;
		width = height * Screen.width / Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void CreateBirds(){
		Instantiate (Birdobj,new Vector3(transform.position.x,transform.position.y+Random.Range(0,width/1.3f),transform.position.z+10),Quaternion.identity);
	}
}

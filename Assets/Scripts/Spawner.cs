using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Spawner : MonoBehaviour {
	public static Spawner instance;
	[SerializeField]
	private GameObject[] obstacles;

	private List<GameObject> obstaclesForSpawing = new List<GameObject> ();
	private float width , height;
	private int place=1 ;
	private int openforthefirsttime=1;
	void Awake(){
		initObstacles ();

		if (instance == null) {
			instance = this;
		}
	}
	void Start () {
		height =   Camera.main.orthographicSize ;
		width = height * Screen.width / Screen.height;
	}
	void initObstacles() {
		int index = 0;
		for (int i = 0; i < obstacles.Length * 4; i++) {
			GameObject obj = Instantiate (obstacles [index], new Vector3(transform.position.x,transform.position.y,
				-2), Quaternion.identity)as GameObject;
			obstaclesForSpawing.Add (obj);
			obstaclesForSpawing [i].SetActive (false);
			index++;
			if(index==obstacles.Length)
				index=0;
		}

	}
	public IEnumerator SpawnRandomObstacle(){
		Debug.Log (CameraMove.instance.getSpeed());
		if(CameraMove.instance.getSpeed()<=0.02f)
		yield return new WaitForSeconds (2f);
		if(CameraMove.instance.getSpeed()>0.02f&&CameraMove.instance.getSpeed()<0.04f)
			yield return new WaitForSeconds (1.5f);
		if(CameraMove.instance.getSpeed()>=0.04f&&CameraMove.instance.getSpeed()<0.06f)
			yield return new WaitForSeconds (1f);
		if(CameraMove.instance.getSpeed()>=0.06f)
			yield return new WaitForSeconds (0.5f);
		
		int index = Random.Range (0,obstaclesForSpawing.Count);

		while (true) {
			if (!obstaclesForSpawing [index].activeInHierarchy) {
				obstaclesForSpawing [index].SetActive (true);
				if (place > 0) {
					obstaclesForSpawing [index].transform.position = new Vector3 (transform.position.x + Random.Range (-width, 0),
						transform.position.y, -2);
					place = -1;
				} else {
					obstaclesForSpawing [index].transform.position = new Vector3 (transform.position.x + Random.Range (0, width),
						transform.position.y, -2);
					place = 1;
				}
				break;
			} else {
				index = Random.Range (0, obstaclesForSpawing.Count);
			}
		}
		if (playerScripts.instance.getcaMove()) {
			StartCoroutine (SpawnRandomObstacle ());
		}
	}


}

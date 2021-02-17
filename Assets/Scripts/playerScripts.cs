using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerScripts : MonoBehaviour {
	public static playerScripts instance;
	private bool canMove = false;
	private float speed=0.1f;
	private int direction;
	[SerializeField]
	private GameObject[] Border;
	public GameObject GameOverPanel;
	public Animator anim;
	public Text scoreText,scoretextOver,hightscoretext;

	private int score=0;

	// Use this for initialization
	void Awake(){


		//anim = GetComponent<Animator> ();
		if(instance==null){
			instance = this;
		}
	}
	void Start () {
		if (Random.Range (0, 100) < 50) {
			direction = -1;
		} else {
			direction = 1;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (canMove) {
			Vector3 temp = transform.position;
			temp.x += speed * direction;
			transform.position = temp;


		}

	}
	void Update(){
		scoreText.text = " " + score;
	}
	public void playerMove(){
		if (!canMove) {
			try{
				anim.SetTrigger ("Run");
			}catch(UnityException e){
				
			}
			StartCoroutine (Spawner.instance.SpawnRandomObstacle());
		
		}
		canMove = true;
		direction = -direction;

		Vector3 temp2 = transform.localScale;
		if (direction > 0) {
			temp2.x = Mathf.Abs (transform.localScale.x);
		} else {
			temp2.x = -Mathf.Abs (transform.localScale.x);
		}
		transform.localScale = temp2;
	}
	public bool getcaMove(){
		return canMove;
	}
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.name == Border[0].name) {
			Vector3 temp = transform.position;
			temp.x = Border [1].transform.position.x+transform.localScale.x;
			transform.position = temp;
		}else if (target.gameObject.name == Border[1].name) {
			Vector3 temp = transform.position;
			temp.x = Border [0].transform.position.x+transform.localScale.x;
			transform.position = temp;
		}
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Border") {
			canMove = false;
			gameObject.SetActive (false);
			if (GameManager.instance.getHighscore () < score) {
				GameManager.instance.setHighScore (score);
				hightscoretext.text = " A New High Score :";
			} else {
				hightscoretext.text = "High Score :" + GameManager.instance.getHighscore ();
			}
			GameOverPanel.SetActive (true);
			scoretextOver.text = "Your Score : "+score;


		} else if (target.gameObject.tag == "Collector") {
			score++;
		}
	}

}

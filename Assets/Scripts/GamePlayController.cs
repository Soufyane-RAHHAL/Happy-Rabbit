using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {
	public GameObject[] Rabbit;
	[SerializeField]
	// Use this for initialization
	void Start () {
		setRabbit ();
	}
	void setRabbit(){
		Rabbit [GameManager.instance.getPlayer ()].SetActive (true);
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void playerButton(){
		playerScripts.instance.playerMove ();
	}
	public void RestartButton(){
		SceneManager.LoadScene ("GamePlay");
	}
	public void GotheMainMenuButton(){
		SceneManager.LoadScene ("MainMenu");
	}
}

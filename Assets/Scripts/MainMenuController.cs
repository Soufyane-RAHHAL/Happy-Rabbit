using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour {
	public static MainMenuController instance;
	public int playernumbre;

	public void male_playerButton(){
		SceneManager.LoadScene("GamePlay");
		GameManager.instance.setPlayer (1);

	}
	public void female_playerButton(){
		SceneManager.LoadScene("GamePlay");
		GameManager.instance.setPlayer (0);


	}
	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

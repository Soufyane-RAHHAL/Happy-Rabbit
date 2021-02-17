using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	private const string SELECTED_PLAYER="player";
	private const string HIGHT_SCORE="High Score";

	// Use this for initialization
	void Awake(){
		MakeSingletone ();
		IsTheGameStartedForTheFirstTime ();
	}
	void MakeSingletone(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
	void IsTheGameStartedForTheFirstTime(){
		if (!PlayerPrefs.HasKey ("IsTheGameStartedForTheFirstTime")) {
			PlayerPrefs.SetInt (HIGHT_SCORE,0);
			PlayerPrefs.SetInt (SELECTED_PLAYER,0);

			PlayerPrefs.SetInt ("IsTheGameStartedForTheFirstTime", 0);
		}
	}
		
	public int getPlayer(){
		return PlayerPrefs.GetInt (SELECTED_PLAYER);
	}
	public void setPlayer(int i){
		PlayerPrefs.SetInt (SELECTED_PLAYER,i);
	}


	public int getHighscore(){
		return PlayerPrefs.GetInt (HIGHT_SCORE);
	}
	public void setHighScore(int i){
		PlayerPrefs.SetInt (HIGHT_SCORE,i);
	}








}

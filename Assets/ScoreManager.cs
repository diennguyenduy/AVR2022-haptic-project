using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public bool TorusTouched = false;

	public Text scoreText;
	//public Text highscoreText;

	int score = 0;
	int highscore = 0;

	private void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		scoreText.text = score.ToString () + " POINTS";
		//highscoreText.text = "HIGHSCORE: " + highscore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddPoint(){
		score += 1;
		scoreText.text = score.ToString () + " POINTS";
	}
}

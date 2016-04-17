using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager1 : MonoBehaviour {

	public static int score = 0;
	int bestScore;
	public GameObject scoreContainer;
	public Text scoreNum;
	public Text scoreNum2;
	public Text bestNum;
	
	// Use this for initialization
	void Awake () {

		bestScore = PlayerPrefs.GetInt("bestScore");
		score = 0;
		scoreContainer.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(BirdMovement1.gameOver){

			if(score > bestScore){

				bestScore = score;
				PlayerPrefs.SetInt("bestScore", bestScore);
				PlayerPrefs.Save();
			}
			scoreContainer.SetActive(true);
		}
		scoreNum.text = "" + score;
		scoreNum2.text = "" + score;
		bestNum.text = "" + bestScore;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart1 : MonoBehaviour {

	public void GameOver(){

		SceneManager.LoadScene("Game");
	}
}
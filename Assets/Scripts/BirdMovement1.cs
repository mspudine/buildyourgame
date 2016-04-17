using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BirdMovement1 : MonoBehaviour {

	Rigidbody2D body;
	public Vector2 forza;
	bool possoPremere = true;
	public static bool hit = false;
	public static bool firstTap = false;
	public static bool gameOver = false;
	int numberOfTaps = 0;
	public int rotazGiu;
	public int rotazSu;
	public float angoloLimite;
	float angle = 0;
	public static bool inviaMessaggio = false;

	void Awake(){

		body = gameObject.GetComponent<Rigidbody2D>();
		gameOver = false;
		hit = false;
		possoPremere = true;
	}
	
	void Update () {

		if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && possoPremere){

			Debug.Log("Premo lo spazio, sono figo.");
			if(numberOfTaps==0){

				firstTap = true;
				numberOfTaps++;
			} else {

				firstTap = false;
			}
			Flap();
			inviaMessaggio = true;
		} else {

			inviaMessaggio = false;
		}
	}

	void Flap(){

		body.velocity = forza;
		body.isKinematic = false;
	}

	void FixedUpdate(){

		if(!hit){

			if(body.velocity.y < angoloLimite){
				
				angle = Mathf.Lerp(angle, -90, -body.velocity.y / rotazGiu);
			} else if (body.velocity.y > angoloLimite){

				angle = Mathf.Lerp(angle, 10, body.velocity.y / rotazSu);
			}
			transform.rotation = Quaternion.Euler(0, 0, angle);
		} else {

			angle = Mathf.Lerp(angle, -90, -body.velocity.y / 100);
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {

		hit = true;
		possoPremere = false;
		if(coll.gameObject.tag == "ground"){

			GameOver();
		}
	}

	public void GameOver(){

		body.isKinematic = true;
		gameOver = true;
	}
}
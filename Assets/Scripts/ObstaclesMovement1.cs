using UnityEngine;
using System.Collections;

public class ObstaclesMovement1 : MonoBehaviour {

	public GameObject[] obstacles;
	bool startToMove = false;
	bool collidersEnabled = false;
	float range;
	Component[][] colliders;

	void Start() {

		colliders = new Component[obstacles.Length][];
		for(int i=0; i<obstacles.Length; i++){

			obstacles[i].SetActive(false);
			colliders[i] = obstacles[i].GetComponentsInChildren<BoxCollider2D>();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(BirdMovement1.firstTap && !startToMove){

			Inizia();
			startToMove = true;
		}
		for(int i=0; i<obstacles.Length; i++){

			if(obstacles[i].transform.position.x < -9f){

				obstacles[i].transform.localPosition = new Vector3(4.9f*range, Random.Range(-2.4f, 4.2f));
				range++;
			}
		}
		if(BirdMovement1.hit){

			for(int i=0; i<obstacles.Length; i++){

				foreach(BoxCollider2D collider in colliders[i])	{

					collider.enabled = false;
				}
			}
			collidersEnabled = false;
		} else if (!collidersEnabled) {

			for(int i=0; i<obstacles.Length; i++){

				foreach(BoxCollider2D collider in colliders[i])	{

					collider.enabled = true;
				}
			}
			collidersEnabled = true;
		}
	}

	void Inizia() {

		float distance = -2 - gameObject.transform.position.x;
		range = (distance/4.9f) + 4;
		for(int i=0; i<(obstacles.Length); i++){

			obstacles[i].SetActive(true);
			obstacles[i].transform.localPosition = new Vector3(4.9f*range, Random.Range(-2.4f, 4.2f));
			range++;
		}
	}
}
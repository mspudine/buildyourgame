using UnityEngine;
using System.Collections;

public class ObjectsMovement1 : MonoBehaviour {

	public GameObject[] sfondi;
	public Vector2 forza;
	Rigidbody2D body;
	float range;
	// Use this for initialization
	void Awake () {

		body = gameObject.GetComponent<Rigidbody2D>();
		body.velocity = forza;
		range = sfondi.Length -1;
	}

	void Update(){

		for(int i=0; i<sfondi.Length; i++){

			if(sfondi[i].transform.position.x < -14f){

				sfondi[i].transform.localPosition = new Vector3(8.9f*range, sfondi[i].transform.localPosition.y, 0);
				range++;
			}
		}
		if(BirdMovement1.hit){

			body.velocity = Vector2.zero;
		} else {

			body.velocity = forza;
		}
	}
}
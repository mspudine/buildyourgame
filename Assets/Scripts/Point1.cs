using UnityEngine;
using System.Collections;

public class Point1 : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {

		ScoreManager1.score++;
	}
}

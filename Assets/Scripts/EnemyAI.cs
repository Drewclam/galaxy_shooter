using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	// speed
	private float speed = 3.0F;
	private float yMax = 4.231822f;
	private float xMax = 9.481674f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// move down 
		Move();
		if (!getIsWithinBoundary()) {
			transform.position = new Vector3(Random.Range(-7.87F, 7.87F), yMax, transform.position.z);
		}
	}

	void Move() {
		transform.Translate(Vector3.down  * speed * Time.deltaTime);
	}

	bool getIsWithinBoundary() {
		if (transform.position.y < -yMax) {
			return false;
		} else {
			return true;
		}
	}
}

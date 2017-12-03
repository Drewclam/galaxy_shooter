using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Movement();
		destroyOffBounds();
	}

	private void Movement() {
		float speed = 12f;
		transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

	private void destroyOffBounds() {
		float maxY = 5.87f;
		if (transform.position.y >= maxY) {
			Destroy(gameObject);
		}
	}
}

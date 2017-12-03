using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	[SerializeField] private float _speed = 12f;
	private float maxY = 5.87f;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		Movement();
		destroyOffBounds();
	}

	private void Movement() {
		transform.Translate(Vector3.up * _speed * Time.deltaTime);
	}

	private void destroyOffBounds() {
		if (transform.position.y >= maxY) {
			Destroy(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	[SerializeField] private float speed = 12f;
	private GameManager gameManager;

	void Start() {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void Update () {
		transform.Translate(Vector3.up * speed * Time.deltaTime);

		if (transform.position.y >= gameManager.maxY) {
			Destroy(gameObject);
		}
	}
}

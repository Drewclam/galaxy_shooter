using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	[SerializeField]
	private float speed = 5.0f;
	private float yMax = 4.231822f;
	private float xMax = 9.481674f;

	// Use this for initialization
	private void Start () {
		transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	private void Update () {
		Movement();
	}

	private void Movement() {
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		// Input and Movement
		transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
		transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

		// Play Area Boundaries
		if (transform.position.y > yMax) {
			transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
		} else if (transform.position.y < -yMax) {
			transform.position = new Vector3(transform.position.x, -yMax, transform.position.z);
		} else if (transform.position.x > xMax) {
			transform.position = new Vector3(-xMax, transform.position.y, transform.position.z);
		} else if (transform.position.x < -xMax) {
			transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
		}
	}
}

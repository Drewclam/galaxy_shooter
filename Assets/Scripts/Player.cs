using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 5.0f;
	public float yMax = 4.231822f;

	public float xMax = 8.310589f;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
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

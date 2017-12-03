using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	[SerializeField] private GameObject laserPrefab;

	private float yMax = 4.231822f;
	private float xMax = 9.481674f;

	[SerializeField] private float speed = 5.0f;
	private float fireRate = 1.0F;
	private float coolDown = 0.0F;
	
	// Use this for initialization
	private void Start () {
		transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	private void Update () {
		Movement();
		Fire();
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

	private void Fire() {
		if (Input.GetKeyDown(KeyCode.Space) && Time.time > coolDown) {
			coolDown = Time.time + fireRate;
			Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + 1.03f, transform.position.z), Quaternion.identity);
		}
	}
}

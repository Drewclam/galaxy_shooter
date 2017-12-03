using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	[SerializeField] private GameObject _laserPrefab;

	private float _yMax = 4.231822f;
	private float _xMax = 9.481674f;

	[SerializeField] private float _speed = 5.0f;
	[SerializeField] private float _fireRate = 0.25F;
	private float _coolDown = 0.0F;
	
	// Use this for initialization
	private void Start () {
		transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	private void Update () {
		Movement();

		if (Input.GetKeyDown(KeyCode.Space) && Time.time > _coolDown) {
			Shoot();
		}
	}

	private void Movement() {
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		// Input and Movement
		transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
		transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

		// Play Area Boundaries
		if (transform.position.y > _yMax) {
			transform.position = new Vector3(transform.position.x, _yMax, transform.position.z);
		} else if (transform.position.y < -_yMax) {
			transform.position = new Vector3(transform.position.x, -_yMax, transform.position.z);
		} else if (transform.position.x > _xMax) {
			transform.position = new Vector3(-_xMax, transform.position.y, transform.position.z);
		} else if (transform.position.x < -_xMax) {
			transform.position = new Vector3(_xMax, transform.position.y, transform.position.z);
		}
	}

	private void Shoot() {
		_coolDown = Time.time + _fireRate;
		Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 1.03f, transform.position.z), Quaternion.identity);
	}
}

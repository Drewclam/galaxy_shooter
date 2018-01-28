using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public int health = 3;
	public bool canTripleShot = false;
	public bool isSpeedUp = false;
	public bool hasShield = false;
	[SerializeField] private GameObject explosionPrefab;
	[SerializeField] private GameObject _laserPrefab;
	[SerializeField] private GameObject _tripleShotPrefab;
	[SerializeField] private GameObject shieldPrefab;

	private float _yMax = 4.231822f;
	private float _xMax = 9.481674f;

	[SerializeField] private float _speed = 5.0F;
	private float _powerUpSpeed = 10.0F;
	[SerializeField] private float _fireRate = 0.25F;
	private float _coolDown = 0.0F;

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

		setPlayBoundary();

		if (isSpeedUp) {
			move(Vector3.right * horizontalInput, _powerUpSpeed);
			move(Vector3.up * verticalInput, _powerUpSpeed);
		} else {
			move(Vector3.right * horizontalInput, _speed);
			move(Vector3.up * verticalInput, _speed);
		}
	}

	private void Shoot() {
		_coolDown = Time.time + _fireRate;
		if (canTripleShot) {
			Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
		} else {
			Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 1.03f, transform.position.z), Quaternion.identity);
		}
	}

	public void powerUp(bool power, bool isPoweredDown) {
		power = true;

		if (isPoweredDown) {
			StartCoroutine(powerDown(power));
		}
	}

	public void powerUpShield() {
		hasShield = true;
		Instantiate(shieldPrefab, transform.position, Quaternion.identity);
	}

	private IEnumerator powerDown(bool power, float coolDown = 5.0F) {
		yield return new WaitForSeconds(coolDown);
		power = false;
	}

	private void move(Vector3 direction, float speed) {
		transform.Translate(direction * speed * Time.deltaTime);
	}

	private void setPlayBoundary() {
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

	public void damage() {
		if (hasShield) {
			GameObject shield = GameObject.FindGameObjectWithTag("Shield");
			Destroy(shield);
			hasShield = false;
		} else {
			health--;
			if (health <= 0) {
				Instantiate(explosionPrefab, transform.position, Quaternion.identity);
				Destroy(this.gameObject);
			}
		}
	}
}

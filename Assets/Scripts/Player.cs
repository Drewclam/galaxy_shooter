﻿using System.Collections;
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
	[SerializeField] private float _speed = 5.0F;
	[SerializeField] private float _fireRate = 0.25F;
	[SerializeField] private GameObject[] engineFires;
	private float _yMax = 4.231822f;
	private float _xMax = 9.481674f;
	private float _powerUpSpeed = 10.0F;
	private float _coolDown = 0.0F;
	private GameManager gameManager;
	private AudioSource audioSource;

	private void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		audioSource = GetComponent<AudioSource>();

		if (gameManager.uIManager != null) {
			gameManager.uIManager.updateLives(health);
		}
	}
	
	private void Update () {
		handleMovement();

		if (Input.GetKeyDown(KeyCode.Space) && Time.time > _coolDown) {
			Shoot();
		}
	}

	private void handleMovement() {
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
		audioSource.Play();
		if (canTripleShot) {
			Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
		} else {
			Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 1.03f, transform.position.z), Quaternion.identity);
		}
	}

	public void powerUpTripleShot() {
		canTripleShot = true;
		StartCoroutine(powerTripleShotDown());
	}

	public void powerUpSpeed() {
		isSpeedUp = true;
		StartCoroutine(powerSpeedDown());
	}

	public void powerUpShield(bool state) {
		GameObject shield = this.gameObject.transform.GetChild(0).gameObject;
		hasShield = state;
		shield.SetActive(state);
	}

	private IEnumerator powerSpeedDown() {
		yield return new WaitForSeconds(5.0F);
		isSpeedUp = false;
	}

	private IEnumerator powerTripleShotDown() {
		yield return new WaitForSeconds(5.0F);
		canTripleShot = false;
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
		int randomFire = Random.Range(0, 2);

		if (hasShield) {
			powerUpShield(false);
		} else {
			engineFires[randomFire].SetActive(true);
			health--;
			gameManager.uIManager.updateLives(health);
			if (health <= 0) {
				gameManager.isGameOver = true;
				gameManager.spawnManager.spawnExplosion(transform.position);
				Destroy(this.gameObject);
			}
		}
	}
}

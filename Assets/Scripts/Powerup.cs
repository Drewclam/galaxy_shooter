using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	// [SerializeField] private GameObject _tripleShotPowerUpPreFab;
	[SerializeField] private float _speed = 3.0F;
	[SerializeField] private int id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * _speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		Player player = other.GetComponent<Player>();

		if (other.tag == "Player" && player != null) {
			if (id == 0) {
				player.tripleShotPowerUp();
			} else if (id == 1) {
				// enable speed power up
				player.speedPowerUp();
			} else if (id == 2) {
				// enable shield power up
			}
			Destroy(gameObject);
		}
	}
}

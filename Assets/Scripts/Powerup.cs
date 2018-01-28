using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
	[SerializeField] private float _speed = 2.0F;
	[SerializeField] private int id;
	
	void Update () {
		transform.Translate(Vector3.down * _speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		Player player = other.GetComponent<Player>();

		if (other.tag == "Player" && player != null) {
			switch (id) {
				case 0: 
					player.powerUp(player.canTripleShot, true);
					break;
				case 1:
					player.powerUp(player.isSpeedUp, true);
					break;
				case 2:
					player.powerUpShield();
					break;
				default:
					break;
			}
			Destroy(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	private float speed = 5.0F;
	private float yMax = 6.46F;

	[SerializeField] private GameObject _explosionPrefab;
	
	void Update () {
		transform.Translate(Vector3.down  * speed * Time.deltaTime);

		if (!getIsWithinBoundary()) {
			float randomX = Random.Range(-7.87F, 7.87F);
			transform.position = new Vector3(randomX, yMax, transform.position.z);
		}
	}

	bool getIsWithinBoundary() {
		return transform.position.y < -yMax ? false : true;
	}

	void OnTriggerEnter2D(Collider2D collided) {
		float randomX = Random.Range(-7.87F, 7.87F);
		Player player = collided.GetComponent<Player>();

		switch(collided.tag) {
			case "Laser":
				if (collided.transform.parent != null) {
					Destroy(collided.transform.parent.gameObject);
				}
				// Instantiate(this.gameObject, new Vector3(randomX, yMax, transform.position.z), Quaternion.identity);
				Destroy(collided.gameObject);
				destroyMe();
				break;
			case "Player":
				// Instantiate(this.gameObject, new Vector3(randomX, yMax, transform.position.z), Quaternion.identity);
				destroyMe();
				player.damage();
				break;
			default:
				break;
		}
	}

	private void destroyMe() {
		Destroy(this.gameObject);
		Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
	}
}

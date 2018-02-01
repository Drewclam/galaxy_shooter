using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	private float speed = 5.0F;
	private float yMax = 6.46F;
	private UIManager uIManager;
	private SpawnManager spawnManager;
	[SerializeField] private GameObject _explosionPrefab;

	void Start() {
		// initialize managers
		uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
		spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
	}
	
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
				Destroy(collided.gameObject);
				destroyMe();
				break;
			case "Player":
				destroyMe();
				player.damage();
				break;
			default:
				break;
		}
	}

	private void destroyMe() {
		uIManager.updateScore();
		Destroy(this.gameObject);
		spawnManager.spawnExplosion(transform.position);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	private float speed = 5.0F;
	private float yMax = 6.46F;
 	private GameManager gameManager;
	[SerializeField] private GameObject _explosionPrefab;

	void Start() {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	void Update () {
		transform.Translate(Vector3.down  * speed * Time.deltaTime);

		if (!getIsWithinBoundary()) {
			Destroy(this.gameObject);
		}
	}

	bool getIsWithinBoundary() {
		return transform.position.y < -yMax ? false : true;
	}

	void OnTriggerEnter2D(Collider2D collided) {
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
		gameManager.uIManager.updateScore();
		Destroy(this.gameObject); 
		gameManager.spawnManager.spawnExplosion(transform.position);
	}
}

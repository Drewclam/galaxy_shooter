using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	private float speed = 5.0F;
	private float yMax = 6.46F;
	
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

	void OnTriggerEnter2D(Collider2D other) {
		Laser laser = other.GetComponent<Laser>();
		
		if (laser != null) {
			float randomX = Random.Range(-7.87F, 7.87F);
			Destroy(laser.gameObject);
			Instantiate(this.gameObject, new Vector3(randomX, yMax, transform.position.z), Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}

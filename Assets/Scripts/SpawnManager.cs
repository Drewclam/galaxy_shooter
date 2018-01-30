using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject[] powerUps;

	void Start() {
		StartCoroutine(spawnEnemyRoutine());
		StartCoroutine(spawnPowerUpRoutine());
	}

	private IEnumerator spawnEnemyRoutine() {
		float yMax = 6.46F;

		while (true) {
			float randomX = Random.Range(-7.87F, 7.87F);
			Instantiate(enemyPrefab, new Vector3(randomX, yMax, transform.position.z), Quaternion.identity);
			yield return new WaitForSeconds(0.5F);
		}
	}

	private IEnumerator spawnPowerUpRoutine() {
		float yMax = 6.46F;

		while (true) {
			float randomX = Random.Range(-7.87F, 7.87F);
			int randomPowerUp = Random.Range(0, 3);
			Instantiate(powerUps[randomPowerUp], new Vector3(randomX, yMax, transform.position.z), Quaternion.identity);
			yield return new WaitForSeconds(5.0F);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject[] powerUps;

	void Start () {
		while (true) {
			StartCoroutine(spawnEnemyRoutine());
		}
	}

	private IEnumerator spawnEnemyRoutine() {
		float randomX = Random.Range(-7.87F, 7.87F);
		float yMax = 6.46F;

		while (true) {
			Instantiate(enemyPrefab, new Vector3(randomX, yMax, transform.position.z), Quaternion.identity);
			yield return new WaitForSeconds(5.0F);
		}
	}
}

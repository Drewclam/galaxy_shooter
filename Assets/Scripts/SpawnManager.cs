using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject[] powerUps;

	// Use this for initialization
	IEnumerator Start () {
		while (true) {
			yield return new WaitForSeconds(5.0F);
			StartCoroutine("spawnEnemy");
		}
	}

	private void spawnEnemy() {
		float randomX = Random.Range(-7.87F, 7.87F);
		float yMax = 6.46F;

		Instantiate(enemyPrefab, new Vector3(randomX, yMax, transform.position.z), Quaternion.identity);
	}
}

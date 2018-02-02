using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject explosionPrefab;
	[SerializeField] private GameObject Player;
	[SerializeField] private GameObject[] powerUps;
	private GameManager gameManager;

	void Start() {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	public void initSpawn() {
		StartCoroutine(spawnEnemyRoutine());
		StartCoroutine(spawnPowerUpRoutine());
	}

	public void spawnPlayer() {
		Instantiate(Player, Vector3.zero, Quaternion.identity);
	}

	private IEnumerator spawnEnemyRoutine() {
		float yMax = 6.46F;

		while (!gameManager.isGameOver) {
			float randomX = Random.Range(-7.87F, 7.87F);
			Instantiate(enemyPrefab, new Vector3(randomX, yMax, transform.position.z), Quaternion.identity);
			yield return new WaitForSeconds(1.0F);
		}
	}

	private IEnumerator spawnPowerUpRoutine() {
		float yMax = 6.46F;

		while (!gameManager.isGameOver) {
			float randomX = Random.Range(-7.87F, 7.87F);
			int randomPowerUp = Random.Range(0, 3);
			Instantiate(powerUps[randomPowerUp], new Vector3(randomX, yMax, transform.position.z), Quaternion.identity);
			yield return new WaitForSeconds(5.0F);
		}
	}

	public void spawnExplosion(Vector3 location) {
		Instantiate(explosionPrefab, location, Quaternion.identity);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public bool isGameOver = true;
	public UIManager uIManager;
	public SpawnManager spawnManager;
	public float maxY = 5.87F;

	void Start() {
		spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
		uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}

	void Update() {
		if (isGameOver) {
			uIManager.showTitle();

			if (Input.GetKeyDown(KeyCode.Space)) {
				isGameOver = false;
				uIManager.resetScore();
				uIManager.hideTitle();
				spawnManager.spawnPlayer();
				spawnManager.initSpawn();
			}
		}
	}
}

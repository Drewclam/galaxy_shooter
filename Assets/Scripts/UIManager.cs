using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
  public Sprite[] lives;
  public Image livesImageDisplay;
  public int score = 0;
  public Text scoreText;
  public bool isGameStarted = false;
  public Image title;

  public SpawnManager spawnManager;

  void Start() {
    spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space) && !isGameStarted) {
      startGame();
    }
  }

	public void updateLives(int currentLives) {
    livesImageDisplay.sprite = lives[currentLives];
  }

  public void updateScore() {
    score += 10;
    scoreText.text = "Score: " + score;
  }

  private void resetScore() {
    score = 0;
    scoreText.text = "Score: " + score;
  }

  public void endGame() {
    isGameStarted = false;
    title.gameObject.SetActive(true);
  }

  public void startGame() {
    isGameStarted = true;
    title.gameObject.SetActive(false);
    resetScore();
    spawnManager.spawnPlayer();
  }
}

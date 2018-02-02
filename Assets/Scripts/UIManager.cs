using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
  public Sprite[] lives;
  public Image livesImageDisplay;
  public int score = 0;
  public Text scoreText;
  public Image title;

	public void updateLives(int currentLives) {
    livesImageDisplay.sprite = lives[currentLives];
  }

  public void updateScore() {
    score += 10;
    scoreText.text = "Score: " + score;
  }

  public void resetScore() {
    score = 0;
    scoreText.text = "Score: " + score;
  }

  public void hideTitle() {
    title.gameObject.SetActive(false);
  }
  
  public void showTitle() {
    title.gameObject.SetActive(true);
  }
}

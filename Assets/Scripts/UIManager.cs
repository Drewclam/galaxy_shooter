using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
  public Sprite[] lives;
  public Image livesImageDisplay;
	public void updateLives(int currentLives) {
    livesImageDisplay.sprite = lives[currentLives];
  }

  public void updateScore() {

  }
}

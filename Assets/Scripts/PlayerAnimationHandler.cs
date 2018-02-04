using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {
	private Animator animator;
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void Update () {
		// if w key pressed or left key pressed
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
			animator.SetBool("isTurningLeft", true);
			animator.SetBool("isTurningRight", false);
		} else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) {
			animator.SetBool("isTurningLeft", false);
		} else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
			animator.SetBool("isTurningRight", true);
		} else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) {
			animator.SetBool("isTurningRight", false);
		}
			// set the isTUrningLeft to true
		// else if w key up or left key up
			// set isTurningLeft to false
	}
}

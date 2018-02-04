using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {
	private Animator animator;
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void Update () {
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
	}
}

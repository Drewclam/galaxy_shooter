using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {
	[SerializeField] private AudioClip audioClip;
	void Start () {
		// GetComponent<AudioSource>().Play();
		AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
		Destroy(this.gameObject, 2.50F);
	}
}

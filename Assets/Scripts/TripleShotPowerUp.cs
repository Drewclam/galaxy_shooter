using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotPowerUp : MonoBehaviour {

	// [SerializeField] private GameObject _tripleShotPowerUpPreFab;
	[SerializeField] private float _speed = 3.0F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * _speed * Time.deltaTime);
	}
}

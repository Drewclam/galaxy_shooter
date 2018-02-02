using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {
	void Start () {
		Destroy(this.gameObject, 2.30F);
	}
}

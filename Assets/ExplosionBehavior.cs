using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour {

	// Use this for initialization
	void AnimationEndCallback() {
		Destroy (gameObject);
	}
}

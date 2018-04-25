using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour {

	// Use this for initialization
	void AnimationEndCallback() {
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		var go = collision.gameObject;

		switch (go.tag) {
		case GameObjectTags.Player:
			PlayerDeathController.Instance.Die();
			break;
		case GameObjectTags.Asteroids:
			Destroy (gameObject);
			break;
		}
	}
}

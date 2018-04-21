using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectTags {
	public const string Player = "Player";
	public const string Enemy = "Enemy";
	public const string Environment = "Environment";
}

public class JumpPadBehavior : MonoBehaviour {
	public Vector2 ForceVector = new Vector2(0.0f, 300.0f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		var rb = coll.gameObject.GetComponent<Rigidbody2D> ();
		switch(coll.gameObject.tag) {
		case GameObjectTags.Player:
			rb.AddForce (ForceVector);
			break;
		}
	}
}

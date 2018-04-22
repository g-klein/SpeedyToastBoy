using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpPadBehavior : MonoBehaviour {
	public Vector2 ForceVector = new Vector2(0.0f, 300.0f);

	void OnCollisionEnter2D(Collision2D coll) {
		var rb = coll.gameObject.GetComponent<Rigidbody2D> ();
		switch(coll.gameObject.tag) {
		    case GameObjectTags.Player:
                SoundManager.Instance.PlaySound("Toaster_Jump_1");
			    rb.AddForce (ForceVector);
			    break;
		}
	}
}

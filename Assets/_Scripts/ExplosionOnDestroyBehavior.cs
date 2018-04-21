using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class ExplosionOnDestroyBehavior : MonoBehaviour
	{
		public GameObject Explosion;
		
		public void OnDestroy() {
			Instantiate (Explosion, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
		}
	}
}


using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class ExplosionOnDestroyBehavior : MonoBehaviour
	{
		public GameObject Explosion;
        [HideInInspector] public bool isQuitting = false;

        void OnApplicationQuit()
        {
            isQuitting = true;
        }        

        public void OnDestroy() {
            if (!isQuitting)
            {
                Instantiate(Explosion, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }
		}
	}
}


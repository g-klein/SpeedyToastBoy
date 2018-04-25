using Assets._Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButterBar : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        {
            SceneManager.LoadScene((int)SceneDescriptions.Winner, LoadSceneMode.Single);
        }
    }
}

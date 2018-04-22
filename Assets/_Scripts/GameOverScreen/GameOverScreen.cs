using Assets._Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene((int)SceneDescriptions.LevelOne, LoadSceneMode.Single);
            PlayerLifeCounter.Instance.ResetLifeCount();
        }	
	}
}

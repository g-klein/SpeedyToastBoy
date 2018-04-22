using Assets._Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour {
    public GameObject LivesUI;
    public GameObject LifeCounterInstance;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(LivesUI, null);
            Instantiate(LifeCounterInstance, null);
            SceneManager.LoadScene((int)SceneDescriptions.LevelOne, LoadSceneMode.Single);
        }	
	}
}

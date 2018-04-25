using AssemblyCSharp;
using Assets._Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathController : MonoBehaviour {
    public static PlayerDeathController Instance;

    void Start()
    {
        Debug.Log("Setting instance");
        Instance = this;
    }

    void Update()
    {
        var player = PlayerInstance.Instance;
        if(player != null && player.gameObject.transform.position.y <= -1)
        {
            Die();
        }
    }

    public void Die()
    {
        var pos = PlayerInstance.Instance.gameObject.transform.position;
        Destroy(PlayerInstance.Instance.gameObject);
        PlayerLifeCounter.Instance.LoseLife();

        if(PlayerLifeCounter.Instance.currentLives >= 0)
        {
            PlayerRespawner.Instance.RespawnPlayer(pos, 3f);
        }
        else
        {
            SetAsteroidQuitting();
            StartCoroutine(LoadGameOverScreen());
        }
    }

    public IEnumerator LoadGameOverScreen()
    {        
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene((int)SceneDescriptions.GameOver, LoadSceneMode.Single);
    }

    //hack to prevent asteroid destroy being called on scene change which causes explosions to remain behind
    void SetAsteroidQuitting()
    {
        var asteroids = GameObject.FindGameObjectsWithTag("Asteroids");

        foreach (GameObject roid in asteroids)
        {
            roid.GetComponent<ExplosionOnDestroyBehavior>().isQuitting = true;
        }
    }
}

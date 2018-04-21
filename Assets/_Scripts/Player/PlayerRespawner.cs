using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour {
    [HideInInspector]
    public static PlayerRespawner Instance;

    public float respawnYValue;
    public GameObject playerPrefab;


	// Use this for initialization
	void Start () {
        Instance = this;
	}

    public void RespawnPlayer(Vector3 position, float delay)
    {
        StartCoroutine(RespawnAfterSeconds(position, delay));
    }

    private IEnumerator RespawnAfterSeconds(Vector3 position, float delay)
    {
        yield return new WaitForSeconds(delay);
        var respawnPos = new Vector3(position.x, respawnYValue, position.z);
        Instantiate(playerPrefab, position, Quaternion.identity);
    }
}

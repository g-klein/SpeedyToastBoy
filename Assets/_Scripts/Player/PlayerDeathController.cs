using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour {
    public GameObject playerPrefab;

    public void Die()
    {
        //TODO: only respawn if you have lives left
        PlayerRespawner.Instance.RespawnPlayer(transform.position, 3f);
        Destroy(gameObject);
    }
}

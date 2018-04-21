using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D collision)
    {
        var go = collision.gameObject;

        switch (go.tag)
        {
            case "Player":
                go.GetComponent<PlayerDeathController>().Die();
                break;
            default:
                Destroy(gameObject);
                break;
        }


        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}

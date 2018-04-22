using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var go = other.gameObject;

        switch (go.tag)
        {
            case GameObjectTags.Player:
                AsteroidSpawner.Instance.SpawnForSeconds(20f);
                Destroy(gameObject);
                break;
        }
    }
}

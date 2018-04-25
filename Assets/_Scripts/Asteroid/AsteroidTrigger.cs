using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    public float SpawnRate;
    public float SpawnTime;

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
                AsteroidSpawner.Instance.SpawnRate = SpawnRate;
                AsteroidSpawner.Instance.SpawnForSeconds(SpawnTime);
                Destroy(gameObject);
                break;
        }
    }
}

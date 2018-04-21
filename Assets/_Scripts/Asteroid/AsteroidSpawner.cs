using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    public float SpawnRate;
    public float TimeSinceLastSpawn;
    public GameObject AsteroidPrefab;
    public float spawnHeight;
    [Range(1,100)]
    public float screenPercentSpawnBounds;

	// Use this for initialization
	void Start () {
        TimeSinceLastSpawn = 0;
	}
	
	// Update is called once per frame
	void Update () {
        TimeSinceLastSpawn += Time.deltaTime;

        if(TimeSinceLastSpawn >= SpawnRate)
        {
            SpawnSausage();
            TimeSinceLastSpawn = 0;
        }
	}

    void SpawnSausage()
    {
        if(PlayerInstance.Instance == null)
        {
            return;
        }

        var screenWidth = Screen.width * (screenPercentSpawnBounds / 100);
        var playerPos = Camera.main.WorldToScreenPoint(PlayerInstance.Instance.transform.position).x;
        var spawnPointX = Random.Range(playerPos - screenWidth, playerPos + screenWidth);

        var worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(spawnPointX, 0, 0));
        var spawnPoint = new Vector3(worldPoint.x, spawnHeight);

        var sausage = Instantiate(AsteroidPrefab, spawnPoint, Quaternion.identity);

        var sausageForce = new Vector3(Random.Range(-20, 20), -35);
        sausage.GetComponent<Rigidbody2D>().AddForce(sausageForce);
    }
}

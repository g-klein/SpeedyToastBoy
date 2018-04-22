using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    public float SpawnRate;
    public float TimeSinceLastSpawn;
	public float Thrust; 
    public GameObject AsteroidPrefab;
    public float spawnHeight;
	[Range(1,100)]
	public float playerOffsetBounds;
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
		var playerPos = Camera.main.WorldToScreenPoint (PlayerInstance.Instance.transform.position);
        var spawnPointX = Random.Range(playerPos.x - screenWidth, playerPos.x + screenWidth);
        var worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(spawnPointX, 0, 0));
        var spawnPoint = new Vector3(worldPoint.x, spawnHeight);

		var sausage = Instantiate(AsteroidPrefab, spawnPoint, Quaternion.identity);
		var playerOffsetWidth = Screen.width * (playerOffsetBounds / 100);
		var playerOffsetLeft = playerPos.x - (.5 * playerOffsetWidth);
		var playerOffsetRight = playerPos.x + (.5 * playerOffsetWidth);
		var randomTarget = Random.Range ((float)playerOffsetLeft, (float)playerOffsetRight);
		var randomTargetVector = new Vector3 (randomTarget, playerPos.y);
		var worldTargetVector = Camera.main.ScreenToWorldPoint (randomTargetVector);
		sausage.transform.rotation = Quaternion.LookRotation(Vector3.forward, sausage.transform.position - worldTargetVector);
		sausage.GetComponent<Rigidbody2D> ().AddForce (sausage.transform.up * -Thrust);

        Destroy(sausage, 5f);
    }
}

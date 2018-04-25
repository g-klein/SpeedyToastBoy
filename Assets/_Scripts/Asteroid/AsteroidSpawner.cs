using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public static AsteroidSpawner Instance;
    private GUIStyle style;

    public bool Spawning;

	// Use this for initialization
	void Start () {
        TimeSinceLastSpawn = 0;
        Spawning = false;
        Instance = this;
        style = new GUIStyle();
        style.fontSize = 32;
        style.normal.textColor = Color.black;
        style.alignment = TextAnchor.MiddleCenter;
    }
	
	// Update is called once per frame
	void Update () {
        TimeSinceLastSpawn = Mathf.Min(TimeSinceLastSpawn + Time.deltaTime, SpawnRate);

        if(Spawning && TimeSinceLastSpawn >= SpawnRate)
        {
            SpawnSausage();
            TimeSinceLastSpawn = 0;
        }
	}

    public IEnumerator SpawnCoroutine(float numberOfSeconds)
    {
        Spawning = true;
        var img = GameObject.Find("RedCanvas").transform.GetChild(0).GetComponent<Image>();
        img.gameObject.SetActive(true);
        img.canvasRenderer.SetAlpha(0);
        img.CrossFadeAlpha(0.3f, 0.3f, true);
        yield return new WaitForSeconds(numberOfSeconds);
        img.CrossFadeAlpha(0f, 0.3f, true);
        Spawning = false;
    }

    public void SpawnForSeconds(float numberOfSeconds)
    {
        StartCoroutine(SpawnCoroutine(numberOfSeconds));
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

    void OnGUI()
    {
        var width = 100;
        var txt = Spawning ? "INCOMING ROCKETS!\r\n Get to a turret!" : "";

        GUI.Label(new Rect(Screen.width / 2 - (width / 2), Screen.height / 3, 200, 200), txt, style);
    }
}

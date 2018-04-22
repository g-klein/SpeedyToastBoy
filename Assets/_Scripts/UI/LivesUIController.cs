using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUIController : MonoBehaviour {
    public Sprite remainingLifeSprite;
    public Sprite missingLifeSprite;
    public GameObject gridContainer;
    public GameObject lifePrefab;

    public static LivesUIController Instance;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Render(int currentLifeCount, int maxLifeCount)
    {
        gridContainer.DestroyAllChildren();
        for(int i = 0; i < maxLifeCount; i++)
        {
            var life = Instantiate(lifePrefab, gridContainer.transform);
            var img = life.GetComponent<Image>();

            if (i < currentLifeCount)
            {
                img.sprite = remainingLifeSprite;
            } else
            {
                img.sprite = missingLifeSprite;
            }
        }
    }
	
}

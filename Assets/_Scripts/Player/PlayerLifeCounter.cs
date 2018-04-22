using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeCounter : MonoBehaviour {
    [HideInInspector] public int currentLives;
    public int maxLives;

    public static PlayerLifeCounter Instance;

    void Start()
    {
        Instance = this;
        currentLives = maxLives;
        DontDestroyOnLoad(gameObject);
        LivesUIController.Instance.Render(currentLives, maxLives);
    }

    internal void ResetLifeCount()
    {
        currentLives = maxLives;
        LivesUIController.Instance.Render(currentLives, maxLives);
    }

    public void LoseLife()
    {
        currentLives--;
        LivesUIController.Instance.Render(currentLives, maxLives);
    }
}

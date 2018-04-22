using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip[] Sounds;
    private Dictionary<string, AudioSource> sourceDict;
    public static SoundManager Instance;

	// Use this for initialization
	void Start () {
        Instance = this;

        sourceDict = new Dictionary<string, AudioSource>();
        foreach(var sound in Sounds)
        {
            var src = gameObject.AddComponent<AudioSource>();
            src.clip = sound;
            sourceDict.Add(sound.name, src);
        }
	}

    public void PlaySound(string name)
    {
        if (sourceDict.ContainsKey(name))
        {
            sourceDict[name].Play();
        }
        else
        {
            Debug.Log("No key found in sound manager with name: " + name);
        }
        
    }
}
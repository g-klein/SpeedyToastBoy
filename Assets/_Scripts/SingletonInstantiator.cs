using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonInstantiator : MonoBehaviour {
    public GameObject[] singletons;


	// Use this for initialization
	void Start () {
        foreach (var singleton in singletons)
        {
            Instantiate(singleton, transform);
        }
	}
}

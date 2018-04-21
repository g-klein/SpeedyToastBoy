using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour {
    public static PlayerInstance Instance;
	// Use this for initialization
	void Start () {
        Instance = this;
	}
}

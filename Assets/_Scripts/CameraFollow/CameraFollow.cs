using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private GameObject objectToFollow;

    void Start()
    {
        objectToFollow = FindPlayer();
    }

    private GameObject FindPlayer()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");

        return players.FirstOrDefault();
    }

	// Use this for initialization
	void LateUpdate () {
        if(objectToFollow == null)
        {
            objectToFollow = FindPlayer();
        }

        if(objectToFollow != null)
        {
            transform.position = new Vector3(objectToFollow.transform.position.x, transform.position.y, transform.position.z);
        }        
	}
}

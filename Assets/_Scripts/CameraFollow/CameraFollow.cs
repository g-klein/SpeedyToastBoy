using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private GameObject objectToFollow;
    
	// Use this for initialization
	void LateUpdate () {
        var objectToFollow = PlayerInstance.Instance;
        if(objectToFollow != null)
        {
            transform.position = new Vector3(objectToFollow.transform.position.x, transform.position.y, transform.position.z);
        }        
	}
}
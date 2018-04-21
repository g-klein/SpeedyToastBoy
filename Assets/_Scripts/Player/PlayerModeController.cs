using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModeController : MonoBehaviour {
    public PlayerMode playerMode;

	// Use this for initialization
	void Start () {
        playerMode = PlayerMode.Platformer;
	}


    void SwitchToPlatformer()
    {
        playerMode = PlayerMode.Platformer;
         GetComponent<PlayerMovement>().enabled = true;
        //TODO: enable 
    }

    void SwitchToTurretMode()
    {
        playerMode = PlayerMode.MissileTurret;
        GetComponent<PlayerMovement>().enabled = false;
        //TODO: enable missile system controller
    }    
}

public enum PlayerMode
{
    Platformer,
    MissileTurret
}

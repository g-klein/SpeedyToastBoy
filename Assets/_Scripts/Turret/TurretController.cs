﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Sprite onSprite;
    public Sprite offSprite;
    public GameObject turretGraphics;
    public GameObject missilePrefab;
    public Transform turretShaftPoint;
    public GameObject turretShaft;
    private SpriteRenderer spriteRenderer;
    private bool turretActive;
    private GUIStyle style;

    public Texture2D aimCursor;

    public float shotCooldown;
    [HideInInspector]private float timeSinceLastShot;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TurnOff();
        timeSinceLastShot = shotCooldown;

        style = new GUIStyle();
        style.fontSize = 40;
        style.normal.textColor = Color.black;
        style.alignment = TextAnchor.MiddleCenter;
        style.fontStyle = FontStyle.Bold;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TurnOn();
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            TurnOff();
        }
    }


    void TurnOn()
    {
        spriteRenderer.sprite = onSprite;
        turretGraphics.SetActive(true);
        turretActive = true;

        Cursor.SetCursor(aimCursor, new Vector2(16,16), CursorMode.Auto);
    }

    void TurnOff()
    {
        spriteRenderer.sprite = offSprite;
        turretGraphics.SetActive(false);
        turretActive = false;

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        if (turretActive)
        {
            CheckForShotInput();
            PointShaft();
        }

        //prevent this from incrementing to infinity just in case..
        timeSinceLastShot = Mathf.Min(timeSinceLastShot + Time.deltaTime, shotCooldown);

        if(turretActive && PlayerInstance.Instance == null)
        {
            TurnOff();
        }
    }

    private void PointShaft()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        turretShaft.transform.up = direction;
    }

    private void CheckForShotInput()
    {
        if(Input.GetMouseButtonDown(0) && timeSinceLastShot >= shotCooldown)
        {
            var fork = Instantiate(missilePrefab, turretShaftPoint.transform.position, turretShaftPoint.transform.rotation);
            SoundManager.Instance.PlaySound("Trow_Rocket");
            Destroy(fork, 5f);
            timeSinceLastShot = 0f;
        }
    }

    private void OnGUI()
    {
        var width = 100;
        var txt = (turretActive && AsteroidSpawner.Instance.Spawning) ? "Click to shoot!" : "";

        GUI.Label(new Rect(Screen.width / 2 - (width / 2), (Screen.height / 3) + 80, 200, 200), txt, style);
    }
}

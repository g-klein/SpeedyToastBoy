using System;
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

    public Texture2D aimCursor;

    public float shotCooldown;
    [HideInInspector]private float timeSinceLastShot;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TurnOff();
        timeSinceLastShot = shotCooldown;
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

        Cursor.SetCursor(aimCursor, Vector2.zero, CursorMode.Auto);
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
            Instantiate(missilePrefab, turretShaftPoint.transform.position, turretShaftPoint.transform.rotation);
        }
    }
}

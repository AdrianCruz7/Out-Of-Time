using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    public GameObject bullet;
    public GameObject startPosition;
    public Rigidbody2D rb;
    Vector2 mousePos;
    Vector2 mouseWorldPos;

    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Shoot();
    }

    void Shoot()
    {
        Vector2 aimDirection = mouseWorldPos - (Vector2)startPosition.transform.position;
        
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Instantiate(square, transform.position, Quaternion.identity);
            Instantiate(bullet, startPosition.transform.position, Quaternion.identity);
        }
    }

    
}

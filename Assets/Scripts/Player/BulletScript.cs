using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform firingPoint;
    public Rigidbody2D rb;
    public Vector2 initialDirection;
    PlayerController player;

    float bulletForce = .2f;

    //curving bullets by replacing initial direction with transform.up

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firingPoint = FindObjectOfType<PlayerAim>().transform;
        player = FindObjectOfType<PlayerController>();
        transform.rotation = firingPoint.rotation;
        initialDirection = transform.up;
    }

    void Update()
    {
        rb.AddForce(initialDirection * bulletForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit something");

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("Hit");
            var enemy = collision.gameObject.GetComponent<BaseEnemy>();
            enemy.Damage(player.GetPlayerDamage());
            Destroy(gameObject);
        }

        if (!collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(gameObject);
        }
    }
    
}

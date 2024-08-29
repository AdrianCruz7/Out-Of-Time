using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public float speed;
    public float health;
    public Rigidbody2D rb;

    public GameObject player;
    public float distance;

    public virtual void Damage(float damageDealt)
    {
        health -= damageDealt;
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}

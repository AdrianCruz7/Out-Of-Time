using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasicEnemyAI : BaseEnemy
{
    bool blitzPlayer = true;
    float aggroRangeMin = 8;
    float aggroRangeMax = 12;

    void Start()
    {
        player = FindAnyObjectByType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0) Death();

        distance = Vector2.Distance(transform.position, player.transform.position);

        if(blitzPlayer) 
        {
            if (distance > aggroRangeMax) return;

            if (distance > aggroRangeMin)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                StartCoroutine(Wait());
                blitzPlayer = false;
            }
        }
    }

    IEnumerator Wait()
    {
        Vector2 forceDirection = (Vector2)player.transform.position - rb.position;
        yield return new WaitForSeconds(1f);
        rb.AddForce(forceDirection * 200, ForceMode2D.Force);
        yield return new WaitForSeconds(.3f);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        blitzPlayer = true;
        Debug.Log("Test");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            var playerScript = player.GetComponent<PlayerController>();
            playerScript.Damage(4);
        }
    }
}

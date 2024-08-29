using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletOfTime : BaseItemScript
{
    // Start is called before the first frame update
    void Start()
    {
        itemID = 1;
        itemName = "Amulet of Time";
        itemDescription = "Time wait for just you apparently";
        timePrice = 30;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PlayerController>().playerTime > timePrice)
        {
            Debug.Log("Amulet of Time acquired!");
            collision.gameObject.GetComponent<PlayerController>().playerItems.Add(this);
            Destroy(gameObject);
        }
    }
}

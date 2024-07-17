using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Added 1 time shard");
            FileDataManager.Instance.AddTimeShards(1);
            Destroy(gameObject);
        }
    }
}

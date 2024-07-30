using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShard : MonoBehaviour
{
    public bool AddShard = false;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && AddShard)
        {
            Debug.Log("Added 1 time shard");
            FileDataManager.Instance.AddTimeShards(1);
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Player") && !AddShard)
        {
            Debug.Log("Removed 1 time shard");
            FileDataManager.Instance.SpendTimeShards(1);
            Destroy(gameObject);
        }
    }
}

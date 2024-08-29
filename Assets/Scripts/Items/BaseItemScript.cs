using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseItemScript : MonoBehaviour
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public float timePrice;

    public virtual void PrintItemNameAndDescription()
    {
        Debug.Log($"Item ID: {itemID}");
        Debug.Log($"Item name: {itemName}");
        Debug.Log($"Item description: {itemDescription}");
    }
}

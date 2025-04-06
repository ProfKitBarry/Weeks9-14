using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Properties of the item
    public string itemName;            // Name of the item
    public string itemDescription;     // Description of the item
    public Sprite itemIcon;            // Sprite image for the item (can be set in Unity Inspector)
    public int itemID;                 // Unique ID for the item
    public GameObject itemPrefab;  // The prefab to instantiate in the scene

    public void InitializeItem(string name, string description, Sprite icon, int id, GameObject prefab)
    {
        itemName = name;
        itemDescription = description;
        itemIcon = icon;
        itemID = id;
        itemPrefab = prefab;
    }

    public virtual void Use()
    {
        //Debug.Log("Using " + itemName + ": " + itemDescription);
        // Placeholder for item-specific behavior (e.g., healing, equipping)
    }
}

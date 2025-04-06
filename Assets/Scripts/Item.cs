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

    // Health value to be added when using the health item
    public float healthValue = 25f; // Default health increase

    private Health playerHealth; // Reference to the player's health script

    void Start()
    {
        // Find the player's Health script. Assuming the player has it.
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    public void InitializeItem(string name, string description, Sprite icon, int id, GameObject prefab)
    {
        itemName = name;
        itemDescription = description;
        itemPrefab = prefab;
    }

    public virtual void Use()
    {
        if (playerHealth != null)
        {
            // Increase health when the health item is used
            playerHealth.IncreaseHealth(healthValue);
        }
    }
}

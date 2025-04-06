using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    // List to hold items in the inventory

    public List<Item> items = new List<Item>();


    // The area within which items will spawn
    public Transform spawnArea;

    // Adjustable spacing between items when spawned
    public float itemSpacing = 2.0f;

    // Variable to track the last spawn position
    private float lastSpawnX;

    // Maximum capacity of the inventory
    public int maxCapacity = 10;

    // List to track instantiated objects in the world
    private List<GameObject> instantiatedItems = new List<GameObject>();

    // Method to add an item to the inventory
    public bool AddItem(Item item)
    {
        if (items.Count < maxCapacity)
        {
            items.Add(item);
            Debug.Log(item.itemName + " added to inventory.");
            // Instantiate the item in the game world
            InstantiateItemInWorld(item);
            return true;
        }
        else
        {
            Debug.Log("Inventory is full.");
            return false;
        }
    }

    // Method to remove an item from the inventory
    public bool RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.itemName + " removed from inventory.");
            return true;
        }
        else
        {
            Debug.Log(item.itemName + " not found in inventory.");
            return false;
        }
    }

    // Method to list all items in the inventory
    public void ListItems()
    {
        if (items.Count == 0)
        {
            Debug.Log("Inventory is empty.");
            return;
        }

        Debug.Log("Inventory Items:");
        foreach (var item in items)
        {
            Debug.Log("Item: " + item.itemName + " - " + item.itemDescription);
        }
    }

    // Method to use an item from the inventory (calls item's Use method)
    public void UseItem(Item item)
    {
        if (items.Contains(item))
        {
            item.Use();  // Call the Use method of the item
        }
        else
        {
            Debug.Log(item.itemName + " not in inventory.");
        }
    }


    // Method to instantiate the item in the game world at a specified position
    private void InstantiateItemInWorld(Item item)
    {
        if (item.itemPrefab != null && spawnArea != null)
        {
            // Calculate the spawn position along the x-axis with spacing
            Vector3 spawnPosition = new Vector3(lastSpawnX - 9, spawnArea.position.y, spawnArea.position.z);

            // Instantiate the item prefab at the calculated position
            Instantiate(item.itemPrefab, spawnPosition, Quaternion.identity);
            Debug.Log(item.itemName + " instantiated at " + spawnPosition);

            // Update the last spawn position based on the spacing
            lastSpawnX += itemSpacing;
        }
        else
        {
            Debug.LogWarning("Item prefab or spawn area not set up.");
        }
    }
}
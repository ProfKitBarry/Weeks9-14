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

    // Variable to store the initial spawn position (default position)
    private float initialSpawnX;

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

    // Method to use all instantiated items in the scene
    public void UseAllInstantiatedItems()
    {
        foreach (GameObject instantiatedItem in instantiatedItems)
        {
            // Get the Item component and call Use() if it exists
            Item item = instantiatedItem.GetComponent<Item>();
            if (item != null)
            {
                item.Use();
            }
        }
        // Destroy all instantiated objects
        foreach (GameObject instantiatedItem in instantiatedItems)
        {
            Destroy(instantiatedItem);
        }
        // Clear the list of instantiated objects
        instantiatedItems.Clear();

        // Clear the inventory list
        items.Clear();
        // Reset last spawn position to the initial spawn position
        lastSpawnX = initialSpawnX;
    }

    // Method to instantiate the item in the game world at a specified position
    private void InstantiateItemInWorld(Item item)
    {
        if (item.itemPrefab != null && spawnArea != null)
        {
            // Calculate the spawn position along the x-axis with spacing
            Vector3 spawnPosition = new Vector3(lastSpawnX -9 , spawnArea.position.y, spawnArea.position.z);

            // Instantiate the item prefab at the calculated position
            GameObject instantiatedItem = Instantiate(item.itemPrefab, spawnPosition, Quaternion.identity);
            Debug.Log(item.itemName + " instantiated at " + spawnPosition);

            // Add the instantiated item to the list
            instantiatedItems.Add(instantiatedItem);

            // Update the last spawn position based on the spacing
            lastSpawnX += itemSpacing;

        }
    }

    // Method to clear the inventory and destroy all instantiated objects
    public void ClearInventory()
    {
        // Destroy all instantiated objects
        foreach (GameObject instantiatedItem in instantiatedItems)
        {
            Destroy(instantiatedItem);
        }

        // Clear the list of instantiated objects
        instantiatedItems.Clear();

        // Clear the inventory list
        items.Clear();
        Debug.Log("Inventory cleared and all items destroyed.");

        // Reset last spawn position to the initial spawn position
        lastSpawnX = initialSpawnX;
    }

    // Update method to check for spacebar press and clear the inventory
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClearInventory();
        }
        // Check if "A" key is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            UseAllInstantiatedItems(); // Call method to use all instantiated items
        }
    }
}
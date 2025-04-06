using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    // List to hold items in the inventory

    public List<Item> items = new List<Item>();

    public Transform spawnArea;  // The area within which items will spawn

    // Maximum capacity of the inventory
    public int maxCapacity = 10;

    // Method to add an item to the inventory
    public bool AddItem(Item item)
    {
        if (items.Count < maxCapacity)
        {
            items.Add(item);
            Debug.Log(item.itemName + " added to inventory.");
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
}
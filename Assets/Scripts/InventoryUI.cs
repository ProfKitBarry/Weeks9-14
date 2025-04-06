using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory; // Reference to the inventory system
    public GameObject inventoryPanel; // The UI Panel where items will be displayed
    public GameObject itemButtonPrefab; // Prefab of the button to represent each item
    public Transform itemButtonParent; // The parent object where buttons will be placed (inside InventoryPanel)

    void Start()
    {
        UpdateInventoryUI();
    }

    // Method to update the UI with the items in the inventory
    public void UpdateInventoryUI()
    {
        // Clear previous UI elements (buttons)
        foreach (Transform child in itemButtonParent)
        {
            Destroy(child.gameObject);
        }

        // Create new buttons for each item in the inventory
        foreach (Item item in inventory.items)
        {
            CreateItemButton(item);
        }
    }

    // Method to create a button for each item
    private void CreateItemButton(Item item)
    {
        // Instantiate a new button from the prefab
        GameObject newItemButton = Instantiate(itemButtonPrefab, itemButtonParent);

        // Set up the button's text (item name) and image (item sprite)
        Text buttonText = newItemButton.GetComponentInChildren<Text>();
        Image buttonImage = newItemButton.GetComponentInChildren<Image>();

        buttonText.text = item.itemName;

        // Assuming each Item has a sprite field for the item image
        if (item.itemIcon != null)
        {
            buttonImage.sprite = item.itemIcon;
        }

        // Optionally, add functionality to the button (like using the item)
        Button button = newItemButton.GetComponent<Button>();
        button.onClick.AddListener(() => UseItem(item));
    }

    // Method to use an item when its button is clicked
    private void UseItem(Item item)
    {
        inventory.UseItem(item);
        UpdateInventoryUI(); // Update UI after using an item (in case it gets removed from inventory)
    }
}

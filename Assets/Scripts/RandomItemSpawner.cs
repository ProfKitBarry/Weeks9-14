using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public Inventory inventory; // Reference to the inventory
    public float minInterval = 2f; // Minimum time interval (in seconds)
    public float maxInterval = 5f; // Maximum time interval (in seconds)

    // List of items to choose from
    public Item[] possibleItems;

    private void Start()
    {
        // Start the process of adding items at random intervals
        StartCoroutine(AddItemAtRandomIntervals());
    }

    private IEnumerator AddItemAtRandomIntervals()
    {
        while (true)
        {
            // Wait for a random time interval
            float interval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(interval);

            // Choose a random item from the list
            Item itemToAdd = possibleItems[Random.Range(0, possibleItems.Length)];
        }
    }
}
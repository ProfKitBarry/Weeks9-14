using UnityEngine;
using UnityEngine.UI;  // For UI components
using TMPro;
using Unity.VisualScripting;  // For TextMesh Pro

public class Health : MonoBehaviour
{
    // The player's health
    public float maxHealth = 100f;
    private float currentHealth;


    // Reference to the UI TextMeshPro component to display health
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize health to maxHealth at the start
        currentHealth = maxHealth;
        UpdateHealthText();  // Update the UI text on start
    }

    // Method to apply damage to the player
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthText();  // Update the UI text after taking damage
    }

    // Method to increase health
    public void IncreaseHealth(float amount)
    {
        Debug.Log("Increasing health by: " + amount);
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Ensure health does not exceed max
        }
        UpdateHealthText(); // Update the health UI
    }

    // Method to update the UI text with the current health
    private void UpdateHealthText()
    {
        Debug.Log("IKAMnAga");
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString("F0");  // Display health as an integer
        }
    }

    // Method to get the current health (if needed by other scripts)
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar; // Reference to the total health bar BG image
    [SerializeField] private Image currentHealthBar; // Reference to the current health bar image

    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10; // Set the total health bar fill based on Max health (10 hearts here)
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10; // Dividing by 10 because there are 10 hearts... 
    }

}

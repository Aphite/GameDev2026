using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image fillImage;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0 , maxHealth);
        UpdateBar();
    }

    void UpdateBar()
    {
        fillImage.fillAmount = currentHealth / maxHealth;
    }

}

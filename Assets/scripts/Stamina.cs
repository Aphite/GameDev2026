using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float drainRate = 25f;
    public float regenRate = 15;
    public float regenDelay = 1f; // Time in seconds before stamina starts regenerating after draining

    public float CurrentStamina { get; private set; }
    
    private float regenTimer = 0f; // Timer to track when to start regenerating stamina
    private bool isDraining = false;

    void Awake()
    {
        CurrentStamina = maxStamina; 
    }

    void Update()
    {
        if (isDraining)
        {
            CurrentStamina = Mathf.Clamp(CurrentStamina - drainRate * Time.deltaTime, 0f, maxStamina);
            regenTimer = regenDelay; // Reset regen timer when draining
        } else
        {
            if (regenTimer > 0f)
            {
                regenTimer -= Time.deltaTime;
            } else
            {
                CurrentStamina = Mathf.Clamp(CurrentStamina + regenRate * Time.deltaTime, 0f, maxStamina);
            }

            isDraining = false; // Reset draining state each frame, will be set to true if DrainStamina is called
        }

    }

    public void DrainStamina() // Call this method to start draining stamina
    {
        isDraining = true;
    }

    public bool HasStamina() // Check if there is any stamina left
    {
        return CurrentStamina > 0f;
    }

}

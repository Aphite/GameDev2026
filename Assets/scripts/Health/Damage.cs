using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damageAmount = 1f; // Amount of damage dealt

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damageAmount); // Call TakeDamage
        }
    }




}

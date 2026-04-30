using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
}
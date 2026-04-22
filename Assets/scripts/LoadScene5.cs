using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene5 : MonoBehaviour
{
 
 
    // void Start()
    // {
    //     Debug.Log("SceneChanger Start: " + SceneManager.GetActiveScene().name);   
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Scene5");
        }
    }
    
}

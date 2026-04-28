using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene2 : MonoBehaviour
{
 
 
    // void Start()
    // {
    //     Debug.Log("SceneChanger Start: " + SceneManager.GetActiveScene().name);   
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(2); // load the scene at INDEX 2, instead of using the scene NAME. Just better this way.
        }
    }
    
}

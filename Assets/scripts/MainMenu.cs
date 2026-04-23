using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1); // load the next scene at index 1 which should be level 1.
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application, does not work in editor. Must build the game and it will work.
    }

}

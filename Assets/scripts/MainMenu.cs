using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        if (StatsTracker.Instance != null)
        {
            StatsTracker.Instance.ResetStats(); // Reset stats in StatsTracker when starting a new game
            StatsTracker.Instance.StartTracking(); // Start tracking stats in StatsTracker when starting a new game
        }
        GameManager.Instance?.ResetGame(); // Reset the game state in GameManager when starting a new game
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene in the build index, which... should be the first level of the game.
        // alternatively, could just specify the scene name or index directly
        // SceneManager.LoadScene("Scene2"); // Load the scene by name
        // SceneManager.LoadScene(2); // Load the scene by index. Better but build settings must be set up correctly ****

    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application, does not work in editor. Must build the game and it will work.
    }

}

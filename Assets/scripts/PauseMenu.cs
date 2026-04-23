using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    /*  
        fyi, serializefield makes the private variable visible in the inspector, so you can assign the pause menu UI game object to it. 
        it keeps variables private but still editable in the inspector.
    */
    [SerializeField] private GameObject pauseMenuUI; // Reference to the pause menu UI, !!! assign in inspector

    [SerializeField] private bool isPaused = false; // whether the game is currently paused
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // note, timescale can lead to unintended registered inputs that happen when time is frozen. will change this. May or may not change this actually...
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // hide the pause menu UI
        AudioListener.pause = false; // resume all audio
        Time.timeScale = 1f; // resume normal time
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // show the pause menu UI
        AudioListener.pause = true; // pause all audio
        Time.timeScale = 0f; // freeze time
        isPaused = true;
    }
}

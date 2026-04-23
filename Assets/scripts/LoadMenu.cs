using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public void menu()
    {
        Time.timeScale = 1f; // Ensure the game is unpaused when returning to the menu
        AudioListener.pause = false; // Unpause audio
        SceneManager.LoadScene(0); // Load the main menu
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public void menu()
    {

        if (LeaderboardManager.Instance != null && StatsTracker.Instance != null)
        {
            LeaderboardEntry entry = StatsTracker.Instance.BuildEntry("Player");
            LeaderboardManager.Instance.SaveEntry(entry);

            Debug.Log(Application.persistentDataPath);
        }

        Time.timeScale = 1f; // Ensure the game is unpaused when returning to the menu
        AudioListener.pause = false; // Unpause audio
        SceneManager.LoadScene(0); // Load the main menu
    }
}

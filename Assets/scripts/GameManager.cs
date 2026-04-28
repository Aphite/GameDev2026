using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance, scripts can read but not write to it!!

    public int score = 0;
    public int goalsReached = 0;
    public int goalsToWin = 3;
    public bool playerWon = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Only game manager can set the instance
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount = 1)
    {
        score += amount;
    }

    public void ReachGoal()
    {
        if (goalsReached < goalsToWin)
            goalsReached++;

        if (goalsReached >= goalsToWin)
        {
            playerWon = true;
    
            // Stop the timer when the player wins
            StatsTracker.Instance?.PauseTracking();
    
            // Save the run to the leaderboard
            if (LeaderboardManager.Instance != null && StatsTracker.Instance != null)
            {
                // "Player" is the default name — swap for a name-entry UI later if desired
                LeaderboardEntry entry = StatsTracker.Instance.BuildEntry("Player");
                LeaderboardManager.Instance.SaveEntry(entry);
            }
        }

    }

    public void ResetGame()
    {
        score = 0;
        goalsReached = 0;
        playerWon = false;
    }
}

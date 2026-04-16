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
            playerWon = true;
    }

    public void ResetGame()
    {
        score = 0;
        goalsReached = 0;
        playerWon = false;
    }
}

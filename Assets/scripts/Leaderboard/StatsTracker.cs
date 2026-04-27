using UnityEngine;

public class StatsTracker : MonoBehaviour
{
    public static StatsTracker Instance { get; private set; }

    // tracked stats
    public int enemiesKilled { get; private set; } = 0;
    public float damageDealt    { get; private set; } = 0f;
    public int itemsPickedUp    { get; private set; } = 0;  // number of items picked up
    public int easterEggsFound  { get; private set; } = 0;
    public float timePlayed     { get; private set; } = 0f; // seconds since reset
    public bool isTracking      { get; private set; } = false;


    void Awake()
    {
         if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isTracking) // Only update time played if tracking is active
        {
            timePlayed += Time.deltaTime;
        }
    }

    public void AddEnemyKill()
    {
        enemiesKilled++;
    }

    public void AddDamageDealt(float damage)
    {
        damageDealt += damage;
    }

    public void AddItemPickup()
        {
            itemsPickedUp++;
        }

    public void AddEasterEgg()
    {
        easterEggsFound++;
    }


    public void StartTracking() // Starts time tracking and allows stats to be updated
    {
        isTracking = true;
    }

    public void PauseTracking() // Pauses time tracking but keeps stats
    {
        isTracking = false;
    }

    public void ResetStats() // Resets all stats to their initial values
    {
        enemiesKilled = 0;
        damageDealt = 0f;
        itemsPickedUp = 0;
        easterEggsFound = 0;
        timePlayed = 0f;
        isTracking = false;
    }

    public LeaderboardEntry BuildEntry(string playerName) // Builds a LeaderboardEntry using the current stats and provided player name
    {
        int finalScore = GameManager.Instance != null ? GameManager.Instance.score : 0; // Get score from GameManager if available, otherwise default to 0
        return new LeaderboardEntry(playerName, finalScore, enemiesKilled, damageDealt, itemsPickedUp, easterEggsFound, timePlayed);
    }


}

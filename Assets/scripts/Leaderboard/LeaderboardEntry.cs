using UnityEngine;
using System;

[Serializable]
public class LeaderboardEntry : MonoBehaviour
{
    public string playerName;
    public int    score;
    public int    enemiesKilled;
    public float  damageDealt;
    public int    itemsPickedUp;
    public int    easterEggsFound;
    public float  timePlayed;       // in seconds
    public string date;  

    public LeaderboardEntry() { }

    public LeaderboardEntry(string playerName, int score, int enemiesKilled, float damageDealt, int itemsPickedUp, int easterEggsFound, float timePlayed)
    {
        this.playerName = playerName;
        this.score = score;
        this.enemiesKilled = enemiesKilled;
        this.damageDealt = damageDealt;
        this.itemsPickedUp = itemsPickedUp;
        this.easterEggsFound = easterEggsFound;
        this.timePlayed = timePlayed;
        this.date = DateTime.Now.ToString("MM/dd/yyyy HH:mm"); // Store the date and time of the entry
    }




    public string FormattedTime()
    {
        int minutes = (int)(timePlayed / 60);
        int seconds = (int)(timePlayed % 60);
        return string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }
}

[Serializable]
public class LeaderboardData // Container class for serializing a list of leaderboard entries
{
    public System.Collections.Generic.List<LeaderboardEntry> entries = new System.Collections.Generic.List<LeaderboardEntry>();
}
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance { get; private set; }

    [Tooltip("Max number of entries to keep on the leaderboard.")]
    public int maxEntries = 10;
 
    private const string FILENAME = "leaderboard.json";
    private string FilePath => Path.Combine(Application.persistentDataPath, FILENAME); // Full path to the leaderboard file
 
    private LeaderboardData data = new LeaderboardData();
 
    // Loads leaderboard data from disk
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadFromDisk();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Sorts entries by score in descending order
    public int SaveEntry(LeaderboardEntry entry)
    {
        data.entries.Add(entry);
        SortEntries();
        // TrimEntries(); commented out, so that it doesn't trim entries and saves every session
        SaveToDisk();
 
        int rank = data.entries.IndexOf(entry) + 1;  // +1 for 1-based rank
        Debug.Log($"[LeaderboardManager] Entry saved. Rank: {rank} | Score: {entry.score}");
        
        // return rank <= maxEntries ? rank : -1;
        return rank;
    }

    // Returns a copy of the current leaderboard entries
    public List<LeaderboardEntry> GetEntries()
    {
        return new List<LeaderboardEntry>(data.entries);
    }

    // Returns the highest score entry, or null if no entries exist
    public LeaderboardEntry GetHighScore()
    {
        if (data.entries.Count == 0) return null;
        return data.entries[0]; // Already sorted descending
    }
    
    // clears all entries from the leaderboard and saves the empty state to disk
    public void ClearLeaderboard()
    {
        data.entries.Clear();
        SaveToDisk();
        Debug.Log("[LeaderboardManager] Leaderboard cleared.");
    }

    private void SortEntries()
    {
        data.entries.Sort((a, b) =>
        {
            int scoreCmp = b.score.CompareTo(a.score);
            if (scoreCmp != 0) return scoreCmp;
            return a.timePlayed.CompareTo(b.timePlayed); // tiebreaker: shorter time is better
        });
    }

     private void TrimEntries()
    {
        if (data.entries.Count > maxEntries)
            data.entries.RemoveRange(maxEntries, data.entries.Count - maxEntries);
    }

    private void SaveToDisk()
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        File.WriteAllText(FilePath, json);
        Debug.Log("[LeaderboardManager] Saved to: " + FilePath);
    }
 
    private void LoadFromDisk()
    {
        if (!File.Exists(FilePath))
        {
            Debug.Log("[LeaderboardManager] No save file found. Starting fresh.");
            return;
        }
 
        string json = File.ReadAllText(FilePath);
        LeaderboardData loaded = JsonUtility.FromJson<LeaderboardData>(json);
 
        if (loaded != null && loaded.entries != null)
        {
            data = loaded;
            SortEntries(); // Ensure order is correct on load
            Debug.Log($"[LeaderboardManager] Loaded {data.entries.Count} entries from disk.");
            Debug.Log("File Path: " + FilePath);
        }
        else
        {
            Debug.LogWarning("[LeaderboardManager] Failed to parse save file. Starting fresh.");
        }
    }




















































}

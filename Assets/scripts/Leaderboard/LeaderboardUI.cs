using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    public GameObject rowPrefab; // Prefab for a single leaderboard entry row
    public Transform contentParent; // Parent transform for leaderboard rows


    public void Open()
    {
        gameObject.SetActive(true);
        Populate(); // Populate the leaderboard with current entries when opened
    }

    void Populate()
    {
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        if (LeaderboardManager.Instance == null) return;

        List<LeaderboardEntry> entries = LeaderboardManager.Instance.GetEntries();

        for (int i = 0; i < entries.Count; i++)
        {
            LeaderboardEntry e = entries[i];
            GameObject row = Instantiate(rowPrefab, contentParent);

            // alternate row color for readability
            Image bg = row.GetComponent<Image>();
            if (bg != null)
                bg.color = (i % 2 == 0) ? new Color(1f, 1f, 1f, 0.05f) : new Color(0f, 0f, 0f, 0.15f);

            // highlight the top 3 scores
            Color rankColor = i == 0 ? Color.yellow : 
                              i == 1 ? new Color(0.75f, 0.75f, 0.75f) :
                              i == 2 ? new Color(0.94f, 0.55f, 0.2f) : Color.white;

            var rankText = row.transform.Find("RankText").GetComponent<TMP_Text>();
            rankText.text = (i + 1).ToString();
            rankText.color = rankColor;

            row.transform.Find("RankText").GetComponent<TMP_Text>().text   = (i + 1).ToString();
            row.transform.Find("NameText").GetComponent<TMP_Text>().text   = e.playerName;
            row.transform.Find("ScoreText").GetComponent<TMP_Text>().text  = e.score.ToString();
            row.transform.Find("KillsText").GetComponent<TMP_Text>().text  = e.enemiesKilled.ToString();
            row.transform.Find("DamageText").GetComponent<TMP_Text>().text = ((int)e.damageDealt).ToString();
            row.transform.Find("ItemsText").GetComponent<TMP_Text>().text  = e.itemsPickedUp.ToString();
            row.transform.Find("EggsText").GetComponent<TMP_Text>().text   = e.easterEggsFound.ToString();
            row.transform.Find("TimeText").GetComponent<TMP_Text>().text   = e.FormattedTime();
            row.transform.Find("DateText").GetComponent<TMP_Text>().text   = e.date;
        }
    }

}

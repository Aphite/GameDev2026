using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    void OnGUI()
    {
        // Reads the time from StatsTracker and displays it for the player to see
        if (StatsTracker.Instance == null) return;
 
        float t = StatsTracker.Instance.timePlayed;
        int minutes = (int)(t / 60);
        int seconds = (int)(t % 60);
 
        GUIStyle style = new GUIStyle();
        style.fontSize = 26;
        style.normal.textColor = Color.white;
        style.alignment = TextAnchor.UpperCenter;
 
        string label = string.Format("Time: {0:D2}:{1:D2}", minutes, seconds);
 
        // Centered at the top of the screen
        GUI.Label(new Rect(Screen.width / 2 - 100, 10, 200, 40), label, style);
    }
}

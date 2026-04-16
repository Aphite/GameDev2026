using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    void OnGUI()
    {
        if (GameManager.Instance == null)
            return;

        GUIStyle style = new GUIStyle();
        style.fontSize = 26;
        style.normal.textColor = Color.white;

        string label = "Score: " + GameManager.Instance.score;

        // when the player reaches scene3, show final score message
        if (SceneManager.GetActiveScene().name == "Scene3")
        {
            label = "Final Score: " + GameManager.Instance.score;
            label += "\nTouch the goal to win!";
        }

        GUI.Label(new Rect(10, 10, 300, 30), label, style);
    }
}

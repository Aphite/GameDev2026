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
        style.alignment = TextAnchor.UpperCenter;
 
        string label = "Score: " + GameManager.Instance.score;
 
        // check if final scene
        bool isFinalScene = SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings -1;

        if (isFinalScene)
        {
            label = "Final Score: " + GameManager.Instance.score;
            label += "\nTouch the goal to end the run!";
        }
 
        // Centered under the timer (timer sits at y=10, this sits below it at y=50)
        GUI.Label(new Rect(Screen.width / 2 - 100, 50, 200, 40), label, style);
    }
}

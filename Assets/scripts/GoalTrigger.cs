using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    bool triggered = false;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // detect when the player reaches a goal, goals are only counted once
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.tag == "Player")
        {
            triggered = true;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(); // Increment the score upon reaching a goal. Reaching a goal progresses a level, updating score. 
                GameManager.Instance.ReachGoal();
                Debug.Log("Goal reached! Total: " + GameManager.Instance.goalsReached);
            }

            if (spriteRenderer != null)
                spriteRenderer.color = Color.blue;
        }
    }
    // display the message only when the player wins
    void OnGUI()
    {
        bool isFinalScene = SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1;

        if (isFinalScene && triggered && GameManager.Instance != null && GameManager.Instance.playerWon)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 48;
            style.normal.textColor = Color.green;

            GUI.Label(
                new Rect(Screen.width/2 - 100, Screen.height/2 -25, 200, 50),
                "You Win!",
                style
            );
        }
    }
}
   


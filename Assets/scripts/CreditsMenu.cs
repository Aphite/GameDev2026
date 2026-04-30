using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel; // to assign credits panel
 
    void Start()
    {
        creditsPanel.SetActive(false); // Hidden at the start
    }
 
    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }
 
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }
}

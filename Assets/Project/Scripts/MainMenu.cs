using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

        public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    
    public void Back()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

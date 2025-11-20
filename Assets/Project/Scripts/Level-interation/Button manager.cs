using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    public ButtonObject buttonA;
    public ButtonObject buttonB;

    // The name of the scene to load
    public string sceneToLoad = "win";

    private bool sceneLoaded = false;

    private void Awake()
    {
        Instance = this;
    }

    public void NotifyButtonPressed(ButtonObject button)
    {
        Debug.Log($"{button.name} was pressed.");

        if (buttonA.isPressed && buttonB.isPressed)
        {
            OnBothButtonsPressed();
        }
    }

    void OnBothButtonsPressed()
    {
        if (sceneLoaded) return; // prevent double-loading

        Debug.Log("Both buttons activated! Loading new scene...");

        // Pause the game
        Time.timeScale = 0f;

        sceneLoaded = true;

        // Load the scene
        SceneManager.LoadScene(sceneToLoad);
    }
}

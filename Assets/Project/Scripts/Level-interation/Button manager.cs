using UnityEngine;
using UnityEngine.SceneManager;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    public ButtonObject buttonA;
    public ButtonObject buttonB;

    public string sceneToLoad = "win";

    private bool sceneLoaded = false;

    // Track if each button has EVER been pressed at least once
    private bool aWasPressed = false;
    private bool bWasPressed = false;

    private void Awake()
    {
        Instance = this;
    }

    public void NotifyButtonPressed(ButtonObject button)
    {
        Debug.Log($"{button.name} was pressed.");

        // Mark whichever button was pressed
        if (button == buttonA) aWasPressed = true;
        if (button == buttonB) bWasPressed = true;

        // If both have ever been pressed at least once, load the scene
        if (aWasPressed && bWasPressed)
        {
            OnBothButtonsEverPressed();
        }
    }

    void OnBothButtonsEverPressed()
    {
        if (sceneLoaded) return; // avoid double load
        sceneLoaded = true;

        Debug.Log("Both buttons have been pressed at least once! Loading scene...");

        // Pause the game
        Time.timeScale = 0f;

        // Load scene
        SceneManager.LoadScene(sceneToLoad);
    }
}

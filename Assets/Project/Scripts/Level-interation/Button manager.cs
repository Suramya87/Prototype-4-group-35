using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    [Header("Buttons")]
    public ButtonObject buttonA;
    public ButtonObject buttonB;

    [Header("Scene Settings")]
    public string sceneToLoad = "win";

    private bool actionTriggered = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        if (buttonA == null)
            buttonA = GameObject.FindWithTag("ButtonA")?.GetComponent<ButtonObject>();
        if (buttonB == null)
            buttonB = GameObject.FindWithTag("ButtonB")?.GetComponent<ButtonObject>();
    }

    public void NotifyButtonPressed(ButtonObject button)
    {
        Debug.Log($"Manager: {button.name} pressed. A={buttonA.isPressed}, B={buttonB.isPressed}");

        if (!actionTriggered && buttonA != null && buttonB != null)
        {
            if (buttonA.isPressed && buttonB.isPressed)
            {
                actionTriggered = true;
                TriggerSceneChange();
            }
        }
    }

    public void NotifyButtonReleased(ButtonObject button)
    {
        // Debug.Log($"Manager: {button.name} released.");
    }

    private void TriggerSceneChange()
    {
        Debug.Log("Both buttons pressed! Changing scene...");
        SceneManager.LoadScene(sceneToLoad);
    }
}

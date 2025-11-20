using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    public ButtonObject buttonA;
    public ButtonObject buttonB;

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
        Debug.Log("Both buttons activated!");

        // ---- PLACE YOUR EVENT HERE ----
        // Example: open a door
        // door.Open();
    }
}

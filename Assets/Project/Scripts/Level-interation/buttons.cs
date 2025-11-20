using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    public bool isPressed = false;
    private int charactersInside = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            charactersInside++;
            CheckPressed();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            charactersInside--;
            CheckPressed();
        }
    }

    void CheckPressed()
    {
        bool previousState = isPressed;
        isPressed = charactersInside >= 2;

        if (isPressed && !previousState)
        {
            ButtonManager.Instance.NotifyButtonPressed(this);
        }
    }
}

using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    [Header("Button Settings")]
    [Tooltip("Tags that can press this button")]
    public string[] allowedTags = { "rabbit", "tutle" };

    [Tooltip("How long the button stays pressed after all objects leave (seconds)")]
    public float pressDurationAfterExit = 1f;

    [Header("Button State")]
    public bool isPressed = false;

    private int objectsOnButton = 0;
    private float releaseTimer = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (string tag in allowedTags)
        {
            if (other.CompareTag(tag))
            {
                objectsOnButton++;

                // Press immediately when first object enters
                if (!isPressed)
                {
                    isPressed = true;
                    ButtonManager.Instance?.NotifyButtonPressed(this);
                    // Debug.Log($"{name} pressed by {other.tag}");
                }

                // Reset release timer because an object is on the button
                releaseTimer = 0f;
                break; // stop checking once matched
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (string tag in allowedTags)
        {
            if (other.CompareTag(tag))
            {
                objectsOnButton--;

                // Start the release timer if no objects remain
                if (objectsOnButton <= 0)
                {
                    releaseTimer = pressDurationAfterExit;
                }
                break;
            }
        }
    }

    private void Update()
    {
        // Count down the timer when no objects are on the button
        if (isPressed && objectsOnButton <= 0)
        {
            releaseTimer -= Time.deltaTime;

            if (releaseTimer <= 0f)
            {
                isPressed = false;
                ButtonManager.Instance?.NotifyButtonReleased(this);
                // Debug.Log($"{name} released after timer");
            }
        }
    }
}

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

            
                if (!isPressed)
                {
                    isPressed = true;
                    ButtonManager.Instance?.NotifyButtonPressed(this);
                    // Debug.Log($"{name} pressed by {other.tag}");
                }

                releaseTimer = 0f;
                break; 
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
        if (isPressed && objectsOnButton <= 0)
        {
            releaseTimer -= Time.deltaTime;

            if (releaseTimer <= 0f)
            {
                isPressed = false;
                ButtonManager.Instance?.NotifyButtonReleased(this);
            }
        }
    }
}

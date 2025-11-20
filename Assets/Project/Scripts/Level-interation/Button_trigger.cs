using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger: " + other.name);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited trigger: " + other.name);
    }
}

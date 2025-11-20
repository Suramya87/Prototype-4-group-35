using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    void Start()
    {
        // Ensure tag is Player
        if (tag != "Player")
            tag = "Player";
    }
}

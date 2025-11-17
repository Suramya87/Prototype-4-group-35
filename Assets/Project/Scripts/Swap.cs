using UnityEngine;
using System.Collections.Generic;

public class CharacterSwitcher : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public GameObject character;
        public MonoBehaviour movementScript;
        public Camera camera;
    }

    public List<CharacterData> characters = new List<CharacterData>();
    private int currentIndex = 0;

    void Start()
    {
        // Disable all at start
        for (int i = 0; i < characters.Count; i++)
        {
            SetCharacterActive(i, false);
        }

        // Enable the first one
        SetCharacterActive(currentIndex, true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // Disable current
        SetCharacterActive(currentIndex, false);

        // Move to next
        currentIndex++;
        if (currentIndex >= characters.Count)
            currentIndex = 0;

        // Enable next
        SetCharacterActive(currentIndex, true);
    }

    void SetCharacterActive(int index, bool active)
    {
        var data = characters[index];
        if (data.camera != null) data.camera.enabled = active;
        if (data.movementScript != null) data.movementScript.enabled = active;
    }
}

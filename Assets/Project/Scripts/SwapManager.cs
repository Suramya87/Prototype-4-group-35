using System.Collections.Generic;
using UnityEngine;
using Project.StateMachine;

public class SwapManager : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public GameObject character;
        public SpriteRenderer possessionIndicator;
        public BasicMovement movementScript;
        public StateMachine stateMachine;
    }

    public List<CharacterData> characters = new List<CharacterData>();
    private int currentIndex = 0;

    private void OnValidate()
    {
        foreach (var characterData in characters)
        {
            if (characterData.character != null)
            {
                characterData.possessionIndicator = characterData.character.transform.GetChild(0).GetComponent<SpriteRenderer>();
                characterData.movementScript = characterData.character.GetComponent<BasicMovement>();
                characterData.stateMachine = characterData.character.GetComponent<StateMachine>();
            }
        }
    }

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
        if (data.movementScript != null) data.possessionIndicator.enabled = active;
        if (data.movementScript != null) data.movementScript.enabled = active;
        if (data.stateMachine != null) data.stateMachine.enabled = !active;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Tooltip("The tags of the things that can press this pressure plate.")]
    [SerializeField] private string[] _allowedTags = { "Rabbit", "Turtle" };
    private HashSet<string> _allowedTagsSet;

	private int _numValidAnimalsOnPlate = 0;
	public bool IsPressed => _numValidAnimalsOnPlate > 0;

	private void Awake()
	{
        _allowedTagsSet = new(_allowedTags);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (_allowedTagsSet.Contains(collision.tag))
		{
			_numValidAnimalsOnPlate++;
			PressurePlateManager.Instance.OnPlatePressed();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
    {
		if (_allowedTagsSet.Contains(collision.tag))
		{
			_numValidAnimalsOnPlate--;
            if (_numValidAnimalsOnPlate < 0) // just in case
            {
                _numValidAnimalsOnPlate = 0;
            }
		}
	}
}

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlateManager : MonoBehaviour
{
	[Header("Singleton")]
	private static PressurePlateManager _instance;
	public static PressurePlateManager Instance => _instance;
	void InitializeSingleton()
	{
		if (!_instance)
		{
			_instance = this;
		}
		if (_instance != this)
		{
			Destroy(gameObject);
		}
	}

	[SerializeField] private PressurePlate _plateA;
	[SerializeField] private PressurePlate _plateB;
	[SerializeField] private SceneAsset _sceneToLoad;

	private void Awake()
    {
		InitializeSingleton();
    }

	public void OnPlatePressed()
	{
		if (_plateA.IsPressed && _plateB.IsPressed)
		{
			SceneManager.LoadScene(_sceneToLoad.name);
		}
	}
}

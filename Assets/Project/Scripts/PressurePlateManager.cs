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

	[SerializeField] private PressurePlate _plate1;
	[SerializeField] private PressurePlate _plate2;
	[SerializeField] private SceneAsset _sceneToLoad;

	private void Awake()
    {
		InitializeSingleton();
    }

	public void OnPlatePressed()
	{
		if (_plate1.IsPressed && _plate2.IsPressed)
		{
			SceneManager.LoadScene(_sceneToLoad.name);
		}
	}
}

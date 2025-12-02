using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNavigator : MonoBehaviour
{
	[SerializeField] private SceneAsset[] _levelScenes = new SceneAsset[3];

	public void OnLevelButtonPressed(int level)
    {
		SceneManager.LoadScene(_levelScenes[level - 1].name);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNavigator : MonoBehaviour
{
	public void OnLevelButtonPressed(int level)
    {
		SceneManager.LoadScene($"Level {level}");
    }
}

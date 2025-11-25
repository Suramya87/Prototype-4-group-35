using UnityEngine;
using UnityEngine.SceneManagement;

public class UiButtonManager : MonoBehaviour
{
	public void OnReturnButtonPressed()
	{
		SceneManager.LoadScene("Level");
	}

	public void OnExitButtonPressed()
	{
		Application.Quit();
	}
}

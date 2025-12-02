using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("rabbit") || collision.CompareTag("tutle"))
		{
			Scene currentScene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(currentScene.name);
		}
	}
}

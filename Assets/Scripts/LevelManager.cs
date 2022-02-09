using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sokabon
{
	public class LevelManager : MonoBehaviour
	{
		public void Restart()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		public void GoToNextLevel()
		{
			int current = SceneManager.GetActiveScene().buildIndex;
			int next = current + 1;
			int total = SceneManager.sceneCountInBuildSettings;
			if (next >= total)
			{
				next = 0;
			}

			SceneManager.LoadScene(next);
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Restart();
			}
		}
	}
}
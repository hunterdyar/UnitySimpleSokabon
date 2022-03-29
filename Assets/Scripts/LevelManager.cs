using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string nextLevel;
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToNextScene()
    {
        //Get the current level build Index
        int current = SceneManager.GetActiveScene().buildIndex;
        
        //increase it by one
        int next = current + 1;
        int total = SceneManager.sceneCountInBuildSettings;
        
        //If we are at the end of our list, just go back to the first level in the list.
        if (next >= total)
        {
            next = 0;
        }

        //go to build index
        SceneManager.LoadScene(next);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            GoToNextScene();
        }
    }
}

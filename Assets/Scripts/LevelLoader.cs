using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    private readonly string START_SCREEN = "Start Screen";
    [SerializeField] int timeToWait = 4;

    private static readonly int SPLASH_SCENE_INDEX = 0;
	// Use this for initialization
	void Start () {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == SPLASH_SCENE_INDEX)
        {
            LoadStarScene();
        }
	}

    public void LoadStarScene()
    {
        if(SceneManager.GetActiveScene().name.Equals("Splash Screen"))
        {
            StartCoroutine(LoadStartSceneWithDelay());
        } else
        {
            SceneManager.LoadScene(START_SCREEN);
        }
    }

    IEnumerator LoadStartSceneWithDelay()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(START_SCREEN);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void GameOver()
    {
        ResetTimer();
        SceneManager.LoadScene("Game Over");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        ResetTimer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    private void ResetTimer()
    {
        Time.timeScale = 1f;
    }


}

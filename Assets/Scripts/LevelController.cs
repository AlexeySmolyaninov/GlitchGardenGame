using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] AudioClip loseSFX;

    GameTimer gameTimer;
    [SerializeField] int amountOfAttackers = 0;

	void Start () {
        gameTimer = FindObjectOfType<GameTimer>();
        winLabel.SetActive(false);
	}

    private void Update()
    {
        CheckIfPlayerWonGame();
    }


    public void AddToAmountOfAttackers(int amount)
    {
        this.amountOfAttackers += Mathf.Abs(amount);
    }

    public void ReduceAmountOfAttackers(int amount)
    {
        this.amountOfAttackers -= Mathf.Abs(amount);
    }

    private void CheckIfPlayerWonGame()
    {
        //logic for boss level
        if (FindObjectOfType<DefenderSpawner>().GetIsBossLevel() && amountOfAttackers <= 0)
        {
            PlayerPrefsController.SetWonGame();
            StartCoroutine(HandleWinCondition());
        }
        //logic for normal levels
        else if (gameTimer != null && 
            gameTimer.TimerFinished() &&
            amountOfAttackers <= 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        Time.timeScale = 0f;
        loseLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(loseSFX, Camera.main.transform.position);
        PlayerPrefsController.SetLostGame();
    }


}

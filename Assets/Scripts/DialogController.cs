using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {

    [SerializeField] Text[] dialogTexts;

    int indexDialog = 0;

	void Start () {
        StopGameTime();
        dialogTexts[indexDialog].gameObject.SetActive(true);
    }

    public void NextDialog()
    {
        if(indexDialog >= dialogTexts.Length - 1)
        {
            EndTutorialAndStartGame();
            return;
        }

        if(indexDialog == dialogTexts.Length - 2)
        {
            GameObject submitButton = GameObject.Find("Submit Button");
            submitButton.GetComponentInChildren<Text>().text = "LET'S GO";
        }

        dialogTexts[indexDialog].gameObject.SetActive(false);
        indexDialog++;
        dialogTexts[indexDialog].gameObject.SetActive(true);
    }

    private void StopGameTime()
    {
        Time.timeScale = 0f;
    }

    private void StartGameTime()
    {
        Time.timeScale = 1f;
    }

    private void EndTutorialAndStartGame()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        StartGameTime();
    }
}

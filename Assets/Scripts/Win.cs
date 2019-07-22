using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {

    [SerializeField] Text headerText;

    private void Start()
    {
        if(PlayerPrefs.GetInt("game complete") == 1)
        {
            UserWon();
        }
    }

    public void UserWon()
    {
        headerText.text = "You won!";
        headerText.color = Color.green;

        foreach(Transform child in transform)
        {
            if (child.gameObject.name.Equals("Lost"))
            {
                child.gameObject.SetActive(false);
            }
            else if (child.gameObject.name.Equals("Win"))
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    [SerializeField] int health = 10;
    Text healthText;

    private void Start()
    {
        health = health / PlayerPrefsController.GetDifficulty();
        healthText = gameObject.GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public void RemoveHealth(int healthAmount)
    {
        this.health -= healthAmount;
        UpdateDisplay();

        if (isGameOver())
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

    private bool isGameOver()
    {
        return health <= 0;
    }

}

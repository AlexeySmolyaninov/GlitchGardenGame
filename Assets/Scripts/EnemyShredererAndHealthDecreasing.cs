using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShredererAndHealthDecreasing : MonoBehaviour {

    HealthDisplay healthDisplay;

    private void Start()
    {
        healthDisplay = FindObjectOfType<HealthDisplay>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Boss"))
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
        else
        {
            healthDisplay.RemoveHealth(1);
        }

        Destroy(collision.gameObject);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 1f;
    [SerializeField] GameObject deathVFX;


    public void RemoveHealth(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (deathVFX)
        {
            GameObject exposion = Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(exposion, 0.5f);
        }
    }

}

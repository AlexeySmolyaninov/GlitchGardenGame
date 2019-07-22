using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(0f, 5f)]
    float currentSpeed = 1f;

    GameObject currentTarget;
    LevelController levelController;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AddToAmountOfAttackers(1);
    }

    private void OnDestroy()
    {
        if (FindObjectOfType<LevelController>() == null) { return; }
        FindObjectOfType<LevelController>().ReduceAmountOfAttackers(1);
    }

    void Update () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        //boss doesn't have attacking animation
        if (gameObject.tag.Equals("Boss")) { return; }

        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        //boss doesn't have attacking animation
        if (gameObject.tag.Equals("Boss")) { return; }

        GetComponent<Animator>().SetBool("isAttacking", true);
        this.currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) {return;}

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.RemoveHealth(damage);
        }
    }

}

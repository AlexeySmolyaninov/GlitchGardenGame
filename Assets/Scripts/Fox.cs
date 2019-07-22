using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Gravestone>())
        {
            animator.SetTrigger("jumpTrigger");
        }
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}

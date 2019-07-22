using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    const string PROJECTILE_PARENT_NAME = "Projectiles";

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    GameObject projectileParent;
    private AttackerSpawner myLaneSpawner;
    Animator animator;
    bool shootNonStop;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (shootNonStop || IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            bool isColoseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isColoseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if(myLaneSpawner == null || 
            myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        return true;
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        newProjectile.transform.parent = projectileParent.transform;
    }

    public void SetShootNonStop(bool shootNonStop)
    {
        this.shootNonStop = shootNonStop;
    }

}

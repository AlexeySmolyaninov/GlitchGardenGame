﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShredderer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile)
        {
            Destroy(projectile.gameObject);
        }
    }
}

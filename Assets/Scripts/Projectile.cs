using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Range(5f, 10f)]
    [SerializeField] float speed = 5f;
    [SerializeField] float damage = 1f;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();
        if (attacker && health)
        {
            health.RemoveHealth(damage);
            Destroy(gameObject);
        }
    }
}

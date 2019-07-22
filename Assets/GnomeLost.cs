using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeLost : MonoBehaviour {

    [SerializeField] float speedMin = 0.4f;
    [SerializeField] float speedMax = 1f;

    float speed;

    private void Start()
    {
        speed = Random.Range(speedMin, speedMax);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}
}

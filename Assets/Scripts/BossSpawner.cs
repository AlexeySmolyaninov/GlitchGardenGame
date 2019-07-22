using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

	[SerializeField] Attacker bossPrefab;

    private void Start()
    {
        Attacker boss = Instantiate(bossPrefab, transform.position, Quaternion.identity);
    }
}

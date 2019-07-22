using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    [SerializeField] float spawnMinSeconds = 1f;
    [SerializeField] float spawnMaxSeconds = 5f;
    [SerializeField] Attacker[] attackers;
    [SerializeField] GameObject portalPrefab;


    bool spawn = true;
    GameTimer gameTimer;
    Coroutine spawningAttackersCoroutine;
    GameObject portal;



    void Start () {
        gameTimer = FindObjectOfType<GameTimer>();
        if (portalPrefab)
        {
            portal = Instantiate(portalPrefab, transform.position, Quaternion.identity);
        }
        spawningAttackersCoroutine = StartCoroutine(SpawningCouroutine());
	}

    private void Update()
    {
        if (gameTimer.TimerFinished())
        {
            StopCoroutine(spawningAttackersCoroutine);
        }
    }

    private IEnumerator SpawningCouroutine()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(spawnMinSeconds, spawnMaxSeconds));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        int indexAttacker = UnityEngine.Random.Range(0, attackers.Length);
        Spawn(indexAttacker);
    }

    private void Spawn(int indexAttacker)
    {
        Attacker newAttacker = Instantiate(
                    attackers[indexAttacker],
                    transform.position,
                    Quaternion.identity);
        newAttacker.transform.parent = transform; // setting the object as a child under the object which has component AttackerSpawner
    }

    public void ClosePortal()
    {
        if (portal)
        {
            portal.GetComponent<Animator>().SetTrigger("closePortal");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Tooltip("Level time in SECONDS")]
    [SerializeField] float levelTime = 10f;

    bool portalClosed = false;
	
	// Update is called once per frame
	void Update () {
        if (TimerFinished()) {
            if (!portalClosed) { CloseAllPortals(); }
            return;
        }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime; // max value is 1, so if 1 second has past then 1/ 10 = 0.1 which is 10%
	}

    public bool TimerFinished()
    {
        return GetComponent<Slider>().value == 1f;
    }

    private void CloseAllPortals()
    {
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            spawner.ClosePortal();
        }

        this.portalClosed = true;
    } 
}

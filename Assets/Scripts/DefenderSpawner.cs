using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    const string DEFENDER_PARENT_NAME = "Defenders";

    [SerializeField] bool isBossLevel = false;

    Defender defender;
    GameObject defenderParent;

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttempToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defender)
    {
        this.defender = defender;
    }

    private void AttempToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector3 roundedWorldPos)
    {
        Defender newDefender = Instantiate(
            defender,
            roundedWorldPos,
            Quaternion.identity);

        /*if isBossLevel var is true then defender will shoot all the time because the enemy doesn't come
         from the attackers spawn lines*/
        Shooter shooter = newDefender.GetComponent<Shooter>();
        if (shooter)
        {
            newDefender.GetComponent<Shooter>().SetShootNonStop(isBossLevel);
        }

        newDefender.transform.parent = defenderParent.transform;
    }

    public bool GetIsBossLevel()
    {
        return this.isBossLevel;
    }


}

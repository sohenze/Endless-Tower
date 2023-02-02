using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LoseUpdate : MonoBehaviour
{
    private PlayerData playerData;
    public int pointsGained;
    private int pointmeister;

    void Awake() {
        playerData = SaveFileHandler.load();       
    }

    // Start is called before the first frame update
    void Start()
    {
        pointmeister = playerData.perks.pointmeister;
        updatePoints();

        SaveFileHandler.save(playerData);
    }

    void updatePoints() {
        int killPoints = (int) ((GameManager.gameLevel + 1) * Player.killCount) / 20;
        pointsGained = Mathf.FloorToInt(killPoints * (1 + (pointmeister * 0.2f)));

        playerData.points += pointsGained;
    }
}
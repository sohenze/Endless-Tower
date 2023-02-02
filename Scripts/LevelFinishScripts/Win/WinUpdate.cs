using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class WinUpdate : MonoBehaviour
{
    private PlayerData playerData;
    private int pointmeister;

    public int pointsGained;
    public int perkObtained;

    void Awake() {
        playerData = SaveFileHandler.load();
    }

    // Start is called before the first frame update
    void Start()
    {
        pointmeister = playerData.perks.pointmeister;
        perkObtained = -1;

        updateLevels();
        updatePoints();
        updatePerks();
        SaveFileHandler.save(playerData);
    }

    void updateLevels() {
        switch (GameManager.gameLevel)
        {
            case 0:
                playerData.levels.level1 = true;
                break;
            case 1:
                playerData.levels.level2 = true;
                break;
            case 2:
                playerData.levels.level3 = true;
                break;
            case 3:
                playerData.levels.level4 = true;
                break;
            case 4:
                playerData.levels.level5 = true;
                break;
            case 5:
                playerData.levels.level6 = true;
                break;
            case 6:
                playerData.levels.level7 = true;
                break;
            case 7:
                playerData.levels.level8 = true;
                break;
            case 8:
                playerData.levels.level9 = true;
                break;
            case 9:
                playerData.levels.level10 = true;
                break;
            case 10:
                playerData.levels.endless = true;
                break;
            default:
                playerData.levels.endlessLevel += 1;
                break;
        }
    }

    void updatePoints() {
        int clearPoints = (GameManager.gameLevel + 1) * 100;
        int killPoints = (int) ((GameManager.gameLevel + 1) * Player.killCount) / 20;
        pointsGained = Mathf.FloorToInt((clearPoints + killPoints) * (1 + (pointmeister * 0.2f)));

        playerData.points += pointsGained;
    }

    void updatePerks() {
        float perkChance = 0.01f;

        switch (GameManager.gameLevel)
        {
            case 0:
                perkChance = 0.01f;
                break;
            case 1:
                perkChance = 0.01f;
                break;
            case 2:
                perkChance = 0.01f;
                break;
            case 3:
                perkChance = 0.01f;
                break;
            case 4:
                perkChance = 0.02f;
                break;
            case 5:
                perkChance = 0.02f;
                break;
            case 6:
                perkChance = 0.02f;
                break;
            case 7:
                perkChance = 0.02f;
                break;
            case 8:
                perkChance = 0.03f;
                break;
            case 9:
                perkChance = 0.04f;
                break;
            case 10:
                perkChance = 0.05f;
                break;
            default:
                perkChance = 0.05f;
                break;
        }

        float perkChanceFinal = perkChance * (playerData.stats.luck + 1.0f);

        if (Random.Range(0.0f , 100.0f) <= perkChanceFinal * 100) {
            perkObtained = rollPerk();
        }
    }

    int rollPerk() {
        int perk = Random.Range(0, 5);
            
        switch (perk)
        {
            case 0:
                playerData.perks.tycoon += 1;
                return 0;

            case 1:
                playerData.perks.legionnaire += 1;
                return 1;
                
            
            case 2:
                playerData.perks.steelblood += 1;
                return 2;

            case 3:
                if (playerData.perks.mage < 1) {
                    playerData.perks.mage += 1;
                    return 3;
                } else {
                    return rollPerk();
                }    
            
            default:
                if (playerData.perks.pointmeister < 5) {
                    playerData.perks.pointmeister += 1;
                    return 4;
                } else {
                    return rollPerk();
                }
        }
    }
}

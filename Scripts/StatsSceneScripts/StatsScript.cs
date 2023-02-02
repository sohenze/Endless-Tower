using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class StatsScript : MonoBehaviour
{
    private PlayerData playerData;
    private TextMeshProUGUI pointsText;
    private TextMeshProUGUI statsText;

    private TextMeshProUGUI atkCostText;
    private TextMeshProUGUI firerateCostText;
    private TextMeshProUGUI critChanceCostText;
    private TextMeshProUGUI critDmgCostText;
    private TextMeshProUGUI maxHPCostText;
    private TextMeshProUGUI HPRegenCostText;
    private TextMeshProUGUI defenseCostText;
    private TextMeshProUGUI goldBonusCostText;
    private TextMeshProUGUI luckCostText;

    void Awake() {
        atkCostText = GameObject.Find("AtkUpgrade").GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        firerateCostText = GameObject.Find("FirerateUpgrade").GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;;
        critChanceCostText = GameObject.Find("CritChanceUpgrade").GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;;
        critDmgCostText = GameObject.Find("CritDmgUpgrade").GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;;
        maxHPCostText = GameObject.Find("MaxHPUpgrade").GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;;
        HPRegenCostText = GameObject.Find("HPRegenUpgrade").GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;;
        defenseCostText = GameObject.Find("DefenseUpgrade").GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;;
        goldBonusCostText = GameObject.Find("GoldBonusUpgrade").GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;;
        luckCostText = GameObject.Find("LuckUpgrade").GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;;
        pointsText = GameObject.Find("PointNumber").GetComponent<TextMeshProUGUI>();
        statsText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        playerData = SaveFileHandler.load();
        

        atkCostText.text = playerData.stats.atkCost + " points";
        firerateCostText.text = playerData.stats.firerateCost + " points";
        critChanceCostText.text = playerData.stats.critChanceCost + " points";
        critDmgCostText.text = playerData.stats.critDmgCost + " points";
        maxHPCostText.text = playerData.stats.maxHPCost + " points";
        HPRegenCostText.text = playerData.stats.HPRegenCost + " points";
        defenseCostText.text = playerData.stats.defenseCost + " points";
        goldBonusCostText.text = playerData.stats.goldBonusCost + " points";
        luckCostText.text = playerData.stats.luckCost + " points";


        pointsText.text = playerData.points.ToString();

        statsText.text = playerData.stats.atk.ToString("F1") + "\n" +
                    playerData.stats.firerate.ToString("F1") + "\n" +
                    playerData.stats.critChance.ToString("P0") + "\n" +
                    playerData.stats.critDmg.ToString("P0") + "\n" +
                    playerData.stats.maxHP.ToString("0") + "\n" +
                    playerData.stats.HPRegen.ToString("F1") + "\n" +
                    playerData.stats.defense.ToString("F1") + "\n" +
                    playerData.stats.goldBonus.ToString("P0") + "\n" +
                    playerData.stats.luck.ToString("P0");
    }

    public void upgradeAtk() {
        if (playerData.points >= playerData.stats.atkCost) {
            playerData.stats.atk += 5f;
            playerData.points -= playerData.stats.atkCost;
            playerData.stats.atkCost += 5;
            SaveFileHandler.save(playerData);
        }
    }
    public void upgradeFirerate() {
        if (playerData.points >= playerData.stats.firerateCost) {
            playerData.stats.firerate += 0.1f;
            playerData.points -= playerData.stats.firerateCost;
            if (playerData.stats.firerate >= 10f) {
                firerateCostText.transform.parent.GetComponent<Button>().interactable = false;
            }
            playerData.stats.firerateCost += 5;
            SaveFileHandler.save(playerData);
        }
    }
    public void upgradeCritChance() {
        if (playerData.points >= playerData.stats.critChanceCost) {
            playerData.stats.critChance += 0.01f;
            playerData.points -= playerData.stats.critChanceCost;
            if (playerData.stats.critChance >= 1.0f) {
                critChanceCostText.transform.parent.GetComponent<Button>().interactable = false;
            }
            playerData.stats.critChanceCost += 5;
            SaveFileHandler.save(playerData);
        }
    }
    public void upgradeCritDmg() {
        if (playerData.points >= playerData.stats.critDmgCost) {
            playerData.stats.critDmg += 0.05f;
            playerData.points -= playerData.stats.critDmgCost;
            playerData.stats.critDmgCost += 5;
            SaveFileHandler.save(playerData);
        }
    }
    public void upgradeMaxHP() {
        if (playerData.points >= playerData.stats.maxHPCost) {
            playerData.stats.maxHP += 20f;
            playerData.points -= playerData.stats.maxHPCost;
            playerData.stats.maxHPCost += 5;
            SaveFileHandler.save(playerData);
        }
    }
    public void upgradeHPRegen() {
        if (playerData.points >= playerData.stats.HPRegenCost) {
            playerData.stats.HPRegen += 0.5f;
            playerData.points -= playerData.stats.HPRegenCost;
            playerData.stats.HPRegenCost += 5;
            SaveFileHandler.save(playerData);
        }
    }
    public void upgradeDefense() {
        if (playerData.points >= playerData.stats.defenseCost) {
            playerData.stats.defense += 0.5f;
            playerData.points -= playerData.stats.defenseCost;
            playerData.stats.defenseCost += 5;
            SaveFileHandler.save(playerData);
        }
    }
    public void upgradeGoldBonus() {
        if (playerData.points >= playerData.stats.goldBonusCost) {
            playerData.stats.goldBonus += 0.01f;
            playerData.points -= playerData.stats.goldBonusCost;
            playerData.stats.goldBonusCost += 5;
            SaveFileHandler.save(playerData);
        }
    }
    public void upgradeLuck() {
        if (playerData.points >= playerData.stats.luckCost) {
            playerData.stats.luck += 0.01f;
            playerData.points -= playerData.stats.luckCost;
            playerData.stats.luckCost += 5;
            SaveFileHandler.save(playerData);
        }
    }
}

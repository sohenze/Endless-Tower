using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    private Player player;

    public float currHP;

    public int level;
    public float atk;
    public float firerate;
    public float critChance;
    public float critDmg;
    public float maxHP;
    public float HPRegen;
    public float defense;

    private TextAsset bossDataJson;
    private BossData bossData;
    private BossStats bossStats;

    void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();

        bossDataJson = Resources.Load<TextAsset>("BossData");
        bossData = JsonUtility.FromJson<BossData>(bossDataJson.text);

        if (GameManager.gameLevel <= 10) {
            bossStats = bossData.stats[GameManager.gameLevel];
        } else {
            bossStats = bossData.stats[10];
        }

        level = bossStats.level;
        atk = bossStats.atk;
        firerate = bossStats.firerate;
        critChance = bossStats.critChance;
        critDmg = bossStats.critDmg;
        maxHP = bossStats.maxHP;
        HPRegen = bossStats.HPRegen;
        defense = bossStats.defense;

        if (GameManager.gameLevel > 10) {
            level = GameManager.gameLevel;
            atk *= Mathf.Pow(1.5f, GameManager.gameLevel - 10);
            firerate *= Mathf.Pow(1.5f, GameManager.gameLevel - 10);
            critChance *= Mathf.Pow(1.5f, GameManager.gameLevel - 10);
            critDmg *= Mathf.Pow(1.5f, GameManager.gameLevel - 10);
            maxHP *= Mathf.Pow(1.5f, GameManager.gameLevel - 10);
            HPRegen *= Mathf.Pow(1.5f, GameManager.gameLevel - 10);
            defense *= Mathf.Pow(1.5f, GameManager.gameLevel - 10);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
        InvokeRepeating("regen", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            InvokeRepeating("attack", 0, 1 / firerate);
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            CancelInvoke();
        }
    }

    void attack() {
        if (Random.Range(0.0f, 100.0f) <= critChance * 100) {
            player.takeDamage(atk * critDmg);
        } else {
            player.takeDamage(atk);
        }

        player.takeDamage(atk);
    }

    public void takeDamage(float dmg) {
        currHP -= dmg;
        if (currHP <= 0) {
            die();
        }
    }

    void die() {
        GameObject.Find("GameManager").GetComponent<GameManager>().win();
        Destroy(gameObject);
    }

    void regen() {
        if (currHP + HPRegen >= maxHP) {
            currHP = maxHP;
        } else {
            currHP += HPRegen;
        }
    }    
}

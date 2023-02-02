using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCombat : MonoBehaviour
{
    private Player player;
    private BuffSpawn buffSpawn;
    private EnemySpawn enemySpawn;

    private TextAsset enemyDataJson;
    private EnemyData enemyData;
    private EnemyStats enemyStats;

    private int deathCount;
    private static float upgradeMult;
    public static bool startDying;

    public float currHP;

    //Base stats
    public int level;
    public float atk;
    public float maxHP;
    public float HPRegen;
    public float defense;
    private float gold; //Gold dropped upon death
    private float buffChance;

    private float playerLuck;
    private float buffChanceFinal; //final buff droprate
    
    void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();
        buffSpawn = GameObject.Find("BuffSpawn").GetComponent<BuffSpawn>();
        enemySpawn = GameObject.Find("EnemySpawn").GetComponent<EnemySpawn>();

        //Initialising stats
        enemyDataJson = Resources.Load<TextAsset>("EnemyData");
        enemyData = JsonUtility.FromJson<EnemyData>(enemyDataJson.text);

        if (GameManager.gameLevel <= 10) {
            enemyStats = enemyData.stats[GameManager.gameLevel];
        } else {
            enemyStats = enemyData.stats[10];
        }
        
        level = enemyStats.level;
        atk = enemyStats.atk;
        maxHP = enemyStats.maxHP;
        HPRegen = enemyStats.HPRegen;
        defense = enemyStats.defense;
        gold = enemyStats.gold;
        buffChance = enemyStats.buffChance;

        if (GameManager.gameLevel > 10) {
            level = GameManager.gameLevel;
            atk *= Mathf.Pow(1.5f, GameManager.gameLevel - 10);
            maxHP *= Mathf.Pow(1.5f, GameManager.gameLevel - 10);
            HPRegen *= Mathf.Pow(1.5f, GameManager.gameLevel - 10);
            defense *= Mathf.Pow(1.5f, GameManager.gameLevel - 10);
            gold += GameManager.gameLevel * 5;
        }
        
    }

    // Start is called before the first frame update
    void Start() {
        startDying = false;
        deathCount = 0;
        upgradeMult = 1.3f;

        currHP = maxHP;
        playerLuck = player.luck;
        buffChanceFinal = buffChance * (playerLuck + 1.0f);
        InvokeRepeating("regen", 0, 1.0f);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            InvokeRepeating("attack", 0.0f, 1.0f);
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            CancelInvoke();
        }
    }

    void attack() {
        player.takeDamage(atk);
    }

    public void takeDamage(float dmg) {
        currHP -= dmg;
        if (currHP <= 0) {
            die();
        }
    }

    void die() {
        checkBuffDrop();
        player.earnGold(gold);
        Player.killCount++;
        player.updateAtk();
        
        if (!startDying) {
            transform.position = enemySpawn.getSpawnPoint();

            deathCount++;
            if ((deathCount == 25) ||
                (deathCount == 25 * 2) ||
                (deathCount == 25 * 3) ||
                (deathCount == 25 * 4)) {
                Upgrade();
            }

            currHP = maxHP;

        } else {
            Destroy(gameObject);
        }
        
    }

    void regen() {
        if (currHP + HPRegen >= maxHP) {
            currHP = maxHP;
        } else {
            currHP += HPRegen;
        }
    }

    
    void checkBuffDrop() {
        if (Random.Range(0.0f, 100.0f) <= buffChanceFinal * 100) {
            buffSpawn.CreateBuff();
        }
    }

    void Upgrade() {
        maxHP *= upgradeMult;
        atk *= upgradeMult;
        gold += 5;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int gameLevel;
    private Player player;
    public static float bossTime = 600f;
    public static float bossBuffer = 10f;
    public static float bossTimer = 30f;

    private bool bossSpawned;

    void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bossSpawned = false;
        spawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void win() {
        IEnumerator coroutine = GameManager.winCoroutine();
        StartCoroutine(coroutine);
    }

    public void lose() {
        IEnumerator coroutine = GameManager.loseCoroutine();
        StartCoroutine(coroutine);
    }


    private static IEnumerator winCoroutine() {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("WinScene");
    }

    private static IEnumerator loseCoroutine() {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("LoseScene");
    }

    void spawnEnemies() {
        EnemySpawn enemySpawn = GameObject.Find("EnemySpawn").GetComponent<EnemySpawn>();
        enemySpawn.initialSpawn();
    }

    void spawnBoss() {
        if (!bossSpawned) {
            bossSpawned = true;
            BossSpawn bossSpawn = GameObject.Find("BossSpawn").GetComponent<BossSpawn>();
            bossSpawn.spawnBoss();
        }
    }
}

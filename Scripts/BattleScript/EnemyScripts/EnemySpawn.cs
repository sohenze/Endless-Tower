using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemy;
    Bounds bounds;
    float posX, posY;
    Vector2 pos;

    public static int enemyLimit;
    private static int enemyCount;
    
    void Awake() {
        bounds = GetComponent<Renderer>().bounds;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyLimit = 5;
        enemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2 getSpawnPoint() {
        posX = Random.Range(bounds.min.x, bounds.max.x);
        posY = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(posX, posY);
    }

    public void spawnEnemy() {
        pos = getSpawnPoint();

        Instantiate(enemy, pos, enemy.transform.rotation);
        enemyCount++;
        if (enemyCount >= enemyLimit) {
            CancelInvoke();
        }
    }

    public void initialSpawn() {
        InvokeRepeating("spawnEnemy", 0.5f, 0.5f);
    }
}

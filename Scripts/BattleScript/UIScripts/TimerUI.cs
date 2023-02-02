using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float time;
    private float countDown;
    private bool bossSpawned;

    void Awake() {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        countDown = GameManager.bossTimer;
        bossSpawned = false;
        time = GameManager.bossTime;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time >= 0) {
            string minutes = (Mathf.Floor(time / 60)).ToString();
            string seconds = (Mathf.Floor(time % 60)).ToString();
            text.text = minutes + ":" +seconds;
        } else if (time < 0 &&
                   time > -GameManager.bossBuffer) {
            text.text = "";
            EnemyCombat.startDying = true;             
        } else {
            spawnBoss();
            text.text = Mathf.Ceil(countDown).ToString();
            countDown -= Time.deltaTime;
            if (countDown <= 0) {
                text.text = "";
                GameObject.Find("GameManager").GetComponent<GameManager>().lose();
            }
        }
    }

    void spawnBoss() {
        if (!bossSpawned) {
            bossSpawned = true;
            BossSpawn bossSpawn = GameObject.Find("BossSpawn").GetComponent<BossSpawn>();
            bossSpawn.spawnBoss();
        }
    }
}

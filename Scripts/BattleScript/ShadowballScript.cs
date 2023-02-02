using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowballScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float bulletSpeed;
    private Player player;
    private float atkFinal;
    private float critChanceFinal;
    private float critDmgFinal;

    // Start is called before the first frame update
    void Start() {
        bulletSpeed = 5.0f;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;

        player = GameObject.Find("Player").GetComponent<Player>();
        atkFinal = player.atkFinal;
    }

    void OnTriggerEnter2D(Collider2D hit) {
        if (hit.tag == "Enemy") {
            EnemyCombat enemy = hit.gameObject.GetComponent<EnemyCombat>();
            enemy.takeDamage(atkFinal * 0.4f);
            
        }

        if (hit.tag == "Boss") {
            BossCombat boss = hit.gameObject.GetComponent<BossCombat>();
            boss.takeDamage(atkFinal * 0.4f);
        }
        
        if (hit.tag == "Wall") {
            Destroy(gameObject);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
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
        critChanceFinal = player.critChanceFinal;
        critDmgFinal = player.critDmgFinal;
    }

    void OnTriggerEnter2D(Collider2D hit) {
        if (hit.tag == "Enemy") {
            EnemyCombat enemy = hit.gameObject.GetComponent<EnemyCombat>();

            if (Random.Range(0.0f, 100.0f) <= critChanceFinal * 100) {
                enemy.takeDamage(atkFinal * critDmgFinal);
            } else {
                enemy.takeDamage(atkFinal);
            }
            
            Destroy(gameObject);
        }

        if (hit.tag == "Boss") {
            BossCombat boss = hit.gameObject.GetComponent<BossCombat>();

            if (Random.Range(0.0f, 100.0f) <= critChanceFinal * 100) {
                boss.takeDamage(atkFinal * critDmgFinal);
            } else {
                boss.takeDamage(atkFinal);
            }
            
            Destroy(gameObject);
        }
        
        if (hit.tag == "Wall") {
            Destroy(gameObject);
        }
    }
}

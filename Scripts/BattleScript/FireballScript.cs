using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float fireballSpeed;
    private Player player;
    private float atkFinal;


    // Start is called before the first frame update
    void Start() {
        fireballSpeed = 5.0f;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * fireballSpeed;

        player = GameObject.Find("Player").GetComponent<Player>();
        atkFinal = player.atkFinal;
    }

    void OnTriggerEnter2D(Collider2D hit) {
        if (hit.tag == "Enemy") {
            EnemyCombat enemy = hit.gameObject.GetComponent<EnemyCombat>();
            enemy.takeDamage(atkFinal * 2);
            
            Destroy(gameObject);
        }

        if (hit.tag == "Boss") {
            BossCombat boss = hit.gameObject.GetComponent<BossCombat>();
            boss.takeDamage(atkFinal * 2);
            
            Destroy(gameObject);
        }
        
        if (hit.tag == "Wall") {
            Destroy(gameObject);
        }
    }
}

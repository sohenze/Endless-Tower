using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb;
    private GameObject target;
    private bool targetAlive;

    void Awake() {
        target = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {
        speed = 3f;
    }

    // Update is called once per frame
    void Update() {
        targetAlive = target.GetComponent<Player>().isAlive;

        if (targetAlive)
        {
            if (target != null) {
                //Tracking target
                Vector2 targetPos = target.transform.position;
                float distanceToTarget = ColliderDistance(target, this.gameObject);
    
                //Rotations
                Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, targetPos - (Vector2)transform.position);
                transform.rotation = toRotate;
    
                //Movement
                if (distanceToTarget > 0) {
                
                    transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                }
            }
    
            target = GameObject.Find("Player");
        }
    }
    
    float ColliderDistance(GameObject a, GameObject b) {
            return Physics2D.Distance(a.GetComponent<Collider2D>(), b.GetComponent<Collider2D>()).distance;
    }

}

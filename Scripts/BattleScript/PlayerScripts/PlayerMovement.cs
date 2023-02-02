using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public PlayerJoystick playerJoystick;
    public bool autoaim;
    public AutoAimColour autoaimColour;

    private Player player;
    public Rigidbody2D rb;
    private GameObject target;

    public Transform firePoint;
    public GameObject bullet;
    public GameObject fireball;
    public GameObject shadowball;
    public GameObject pulse;

    public float firePerSec;

    

    void Awake() {
        player = gameObject.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start() {        
        autoaim = false;

        firePerSec = 1.0f / player.firerateFinal;
        startshoot();

        if (player.mage == 1) {
            startFireball();
            startShadowball();
            startPulse();
        }
    }

    // Update is called once per frame
    void Update() {
        float newFirePerSec = 1.0f / player.firerateFinal;
        if (newFirePerSec != firePerSec) {
            firePerSec = newFirePerSec;
            stopshoot();
            startshoot();
        }

        if (playerJoystick.joystickVec.y != 0) {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, playerJoystick.joystickVec);
        }

    }

    public void shoot() {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    public void startshoot() {
        InvokeRepeating("shoot", 0f, firePerSec);
    }

    public void stopshoot() {
        CancelInvoke("shoot");
    }

    public void shootFireball() {
        Instantiate(fireball, firePoint.position, firePoint.rotation);
    }

    public void startFireball() {
        InvokeRepeating("shootFireball", 0f, 1.0f);
    }

    public void shootShadowball() {
        Instantiate(shadowball, firePoint.position, firePoint.rotation);
    }

    public void startShadowball() {
        InvokeRepeating("shootShadowball", 0f, 1.0f);
    }

    public void createPulse() {
        Instantiate(pulse, firePoint.position, firePoint.rotation);
    }

    public void startPulse() {
        InvokeRepeating("createPulse", 0f, 5.0f);
    }

    //Distance between colliders of 2 objects
    float ColliderDistance(GameObject a, GameObject b) {
            return Physics2D.Distance(a.GetComponent<Collider2D>(), b.GetComponent<Collider2D>()).distance;
    }

    //Targets closest enemy
    public void targetClosestEnemy() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length != 0) {
            GameObject closest = null;
            float minDist = Mathf.Infinity;
            foreach (GameObject e in enemies) {
                float distance = ColliderDistance(this. gameObject, e);
                if (distance < minDist) {
                    minDist = distance;
                    closest = e;
                }
            }
            target = closest;
        } else {
            target = GameObject.FindWithTag("Boss");
        }

        if (target != null) {
            Vector2 targetPos = target.transform.position;
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, targetPos - (Vector2)transform.position);
            transform.rotation = toRotate;
        }
        
    }

    public void startAutoaim() {
        InvokeRepeating("targetClosestEnemy", 0f, 0.1f);
        autoaim = true;
        autoaimColour.toggleColor();
    }

    public void stopAutoaim() {
        CancelInvoke("targetClosestEnemy");
        autoaim = false;
        autoaimColour.toggleColor();
    }
    
    public void toggleAutoaim() {
        if (autoaim) {
            stopAutoaim();
        } else {
            startAutoaim();
        }
    }

    public void startAutoaimTemp() {
        InvokeRepeating("targetClosestEnemy", 0f, 0.1f);
    }

    public void stopAutoaimTemp() {
        CancelInvoke("targetClosestEnemy");
    }
}

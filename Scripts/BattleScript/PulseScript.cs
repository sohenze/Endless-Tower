using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float pulseSpeed;
    private Player player;
    private float atkFinal;


    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        atkFinal = player.atkFinal;

        StartCoroutine(scaleOverTime(gameObject.transform, new Vector3(2, 2, 90), 2f));
    }

    void OnTriggerEnter2D(Collider2D hit) {
        if (hit.tag == "Enemy") {
            EnemyCombat enemy = hit.gameObject.GetComponent<EnemyCombat>();
            enemy.takeDamage(atkFinal * 0.2f);
        }

        if (hit.tag == "Boss") {
            BossCombat boss = hit.gameObject.GetComponent<BossCombat>();
            boss.takeDamage(atkFinal * 0.2f);
        }
    
    }

    IEnumerator scaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
    {
        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = objectToScale.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            objectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            yield return null;
        }
        Destroy(gameObject);
    }
}

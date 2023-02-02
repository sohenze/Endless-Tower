using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSpawn : MonoBehaviour
{
    public Player player;

    public float respawnDuration;
    private float respawnCountdown;
    public GameObject respawnText;
    public TextMeshProUGUI text;

    void Awake() {
        player = gameObject.GetComponent<Player>();
        respawnDuration = 5.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        respawnText.SetActive(false);
        respawnCountdown = respawnDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.lives > 0) {
            if (!player.isAlive) {
                text.text = (Mathf.Ceil(respawnCountdown)).ToString();
                respawnText.SetActive(true);
                respawnCountdown -= Time.deltaTime;

                if (respawnCountdown <= 0) {
                    respawnCountdown = respawnDuration;
                    player.spawn();
                    respawnText.SetActive(false);
                }
            }
        }
    }
}

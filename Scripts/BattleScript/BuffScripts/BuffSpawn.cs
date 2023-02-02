using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffSpawn : MonoBehaviour
{

    private Object[] buffArr;
    private Player player;
    private Vector3 spawnPoint;

    void Awake() {
        buffArr = Resources.LoadAll("Buffs", typeof(GameObject));
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.transform.position;
        Instantiate(buffArr[3], spawnPoint, 
            Quaternion.identity, gameObject.transform);
    }

    public void CreateBuff() {
        int buffIndex = Random.Range(0, buffArr.Length);
        Instantiate(buffArr[buffIndex], spawnPoint, 
            Quaternion.identity, gameObject.transform);
    }
}

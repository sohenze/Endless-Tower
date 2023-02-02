using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Buttons : MonoBehaviour
{

    void Awake() {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/PlayerData.json")) {
            GameObject.Find("StatsButton").GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSelectLevel() {
        SceneManager.LoadScene("SelectLevel");
    }

    public void LoadStatsScene() {
        SceneManager.LoadScene("StatsScene");
    }

    public void LoadPerksScene() {
        SceneManager.LoadScene("PerksScene");
    }
}

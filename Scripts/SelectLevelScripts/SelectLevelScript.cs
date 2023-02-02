using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SelectLevelScript : MonoBehaviour
{
    public static int endlessLevel;
    private PlayerData playerData;

    private Component[] componentButtons;
    private Button[] buttons;

    void Awake() {
        playerData = JsonUtility.FromJson<PlayerData>(File.ReadAllText(Application.persistentDataPath + "/PlayerData.json"));
        endlessLevel = playerData.levels.endlessLevel;

        componentButtons = GameObject.Find("Canvas").GetComponentsInChildren(typeof(Button));
        buttons = new Button[componentButtons.Length];
        for (int i = 0; i < componentButtons.Length; i++) {
            buttons[i] = (Button) componentButtons[i];
        }
        
    }

    void Start() {
        buttons[0].interactable = playerData.levels.level0;
        buttons[1].interactable = playerData.levels.level1;
        buttons[2].interactable = playerData.levels.level2;
        buttons[3].interactable = playerData.levels.level3;
        buttons[4].interactable = playerData.levels.level4;
        buttons[5].interactable = playerData.levels.level5;
        buttons[6].interactable = playerData.levels.level6;
        buttons[7].interactable = playerData.levels.level7;
        buttons[8].interactable = playerData.levels.level8;
        buttons[9].interactable = playerData.levels.level9;
        buttons[10].interactable = playerData.levels.level10;
        buttons[11].interactable = playerData.levels.endless;
    }

    void Update() {
        
    }

    public void LoadLevel0() {
        GameManager.gameLevel = 0;
        SceneManager.LoadScene("Level");
    }

    public void LoadLevel1() {
        GameManager.gameLevel = 1;
        SceneManager.LoadScene("Level");
    }

    public void LoadLevel2() {
        GameManager.gameLevel = 2;
        SceneManager.LoadScene("Level");
    }
    
    public void LoadLevel3() {
        GameManager.gameLevel = 3;
        SceneManager.LoadScene("Level");
    }

    public void LoadLevel4() {
        GameManager.gameLevel = 4;
        SceneManager.LoadScene("Level");
    }

    public void LoadLevel5() {
        GameManager.gameLevel = 5;
        SceneManager.LoadScene("Level");
    }

    public void LoadLevel6() {
        GameManager.gameLevel = 6;
        SceneManager.LoadScene("Level");
    }

    public void LoadLevel7() {
        GameManager.gameLevel = 7;
        SceneManager.LoadScene("Level");
    }

    public void LoadLevel8() {
        GameManager.gameLevel = 8;
        SceneManager.LoadScene("Level");
    }

    public void LoadLevel9() {
        GameManager.gameLevel = 9;
        SceneManager.LoadScene("Level");
    }

    public void LoadLevel10() {
        GameManager.gameLevel = 10;
        SceneManager.LoadScene("Level");
    }

    public void LoadLevelEndless() {
        GameManager.gameLevel = 10 + endlessLevel;
        SceneManager.LoadScene("Level");
    }

    public void back() {
        SceneManager.LoadScene("MainMenu");
    }
}

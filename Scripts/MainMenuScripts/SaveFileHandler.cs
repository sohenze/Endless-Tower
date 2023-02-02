using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SaveFileHandler : MonoBehaviour
{
    private TextAsset defPlayerDataJson;
    private PlayerData defPlayerData;
    private PlayerData playerData;

    void Awake() {
        // defPlayerDataJson = Resources.Load<TextAsset>("PlayerData");
        // defPlayerData = JsonUtility.FromJson<PlayerData>(defPlayerDataJson.text);

        // if (!File.Exists(Application.persistentDataPath + "/PlayerData.json")) { 
        //     File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", JsonUtility.ToJson(defPlayerData));
        // }

        // playerData = JsonUtility.FromJson<PlayerData>(File.ReadAllText(Application.persistentDataPath + "/PlayerData.json"));

        defPlayerData = loadR();

        if (!File.Exists(Application.persistentDataPath + "/PlayerData.json")) {
            save(defPlayerData);
        }

        playerData = load();
        playerData.versionCode = defPlayerData.versionCode;
        save(playerData);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static PlayerData loadR() {
        return JsonUtility.FromJson<PlayerData>(Resources.Load<TextAsset>("PlayerData").text);
    }

    public static PlayerData load() {
        return JsonUtility.FromJson<PlayerData>(File.ReadAllText(Application.persistentDataPath + "/PlayerData.json"));
    }

    public static void save(PlayerData saveFile) {
        File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", JsonUtility.ToJson(saveFile));
    }
}

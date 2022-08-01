using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string userName;
    public int highScore;

    public string savedUserName;
    public int savedHighScore;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadUser();
    }

    [System.Serializable]
    class SaveData
    {
        public string username;
        public int highScore;
    }

    public void SaveUser()
    {
        if (highScore < savedHighScore)
        {
            return;
        }

        SaveData data = new SaveData();
        data.username = userName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadUser()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            savedUserName = data.username;
            savedHighScore = data.highScore;
        }
    }

}

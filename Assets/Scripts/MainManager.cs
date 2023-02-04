using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainManager : MonoBehaviour
{
    private static MainManager _instance;
    public static MainManager Instance { get { return _instance; } }

    public string PlayerName;
    public string HighScorePlayerName;
    public int HighScore;


    private void Awake()
    {
        ImplementSingleton();
        LoadHighScore();
    }
    
    private void ImplementSingleton()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string HighScorePlayerName;
        public int HighScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScorePlayerName = HighScorePlayerName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayerName = data.HighScorePlayerName;
            HighScore = data.HighScore;
        }
    }

    public void ClearHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

}

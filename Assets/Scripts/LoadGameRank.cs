using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class LoadGameRank : MonoBehaviour
{
    public Text bestPlayerName;
    private static string bestPlayer;
    private static int bestScore;


    
    private void Awake()
    {
        LoadtheGameRank();
    }

    private void SetBestPlayer()
    {
        if (bestPlayer == null && bestScore == 0)
        {
            bestPlayerName.text = "";
        }
        else
        {
            bestPlayerName.text = $"Best Score - {bestPlayer}:{bestScore}";
        }
    }

    public void LoadtheGameRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.theBestPLayer;
            bestScore = data.theBestScore;
            SetBestPlayer();
        }
    }
    [System.Serializable]
    class SaveData
    {
        public string theBestPLayer;
        public int theBestScore;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public class NameScoreMain
    {
        public string name;
        public int score;

        public NameScoreMain(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public List<string> name = new List<string>();
        public List<int> score = new List<int>();
    }

    // Variables para flujo de datos entre escenas
    public List<NameScoreMain> tableScore = new List<NameScoreMain>();
    public string nickName;
    
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        LoadTableScore();

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateTableScore()
    {
        tableScore = tableScore.OrderBy(data => data.score).ToList();
        tableScore.Reverse();
        
        while (tableScore.Count > 10)
        {
            tableScore.Remove(tableScore[tableScore.Count - 1]);
        }
    }

    public void LoadTableScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            int lengthData = data.name.Count;
            List<NameScoreMain> loadTableScore = new List<NameScoreMain>();

            for (int i = 0; i < lengthData; i++)
            {
                loadTableScore.Add(new NameScoreMain(data.name[i], data.score[i]));
            }

            tableScore = loadTableScore;
        }
    }

    public void SaveTableScore()
    {
        SaveData data = new SaveData();

        UpdateTableScore();

        foreach (var score in tableScore)
        {
            data.name.Add(score.name);
            data.score.Add(score.score);
        }

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";        

        File.WriteAllText(path, json);
        
    }
}

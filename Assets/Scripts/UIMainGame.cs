using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIMainGame : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI nickNameText;
    public TextMeshProUGUI bestScoreText;
    private SpawnManager spawnManager;
    public GameObject gameOverText;
    public GameObject newRocordText;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        UpdateInfo();
        scoreText.SetText("Puntaje: 0");
    }

    private void UpdateInfo()
    {
        if (MainManager.Instance != null)
        {
            nickNameText.SetText("Apodo: " + MainManager.Instance.nickName);
            if(MainManager.Instance.tableScore.Count > 0)
            {
                bestScoreText.SetText("Mejor Puntaje: "
                                    + MainManager.Instance.tableScore[0].name + " : "
                                    + MainManager.Instance.tableScore[0].score);
            }
            else
            {
                bestScoreText.SetText("Mejor Puntaje: --- : ---");
            }
            
        }
    }

    public void UpdateScore()
    {
        score += 5;
        scoreText.SetText("Puntaje: " + score);
    }

    public void GameOver()
    {
        if (MainManager.Instance.tableScore.Count > 0)
        {
            if (score > MainManager.Instance.tableScore[0].score)
            {
                newRocordText.SetActive(true);
            }
        }
        else
        {
            newRocordText.SetActive(true);
        }
        
        MainManager.Instance.tableScore.Add(new MainManager.NameScoreMain(MainManager.Instance.nickName, score));
        MainManager.Instance.SaveTableScore();
        
        UpdateInfo();
        
        spawnManager.isGaming = false;
        gameOverText.SetActive(true);

        
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}

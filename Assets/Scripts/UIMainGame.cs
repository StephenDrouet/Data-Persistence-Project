using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIMainGame : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI nickNameText;
    private SpawnManager spawnManager;
    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (MainManager.Instance != null)
        {
            nickNameText.SetText("Apodo: " + MainManager.Instance.nickName);
        }
        scoreText.SetText("Puntaje: 0");
    }

    public void UpdateScore()
    {
        score += 5;
        scoreText.SetText("Puntaje: " + score);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        spawnManager.isGaming = false;
        gameOverText.SetActive(true);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScoresScript : MonoBehaviour
{
    public TextMeshProUGUI namesText;
    public TextMeshProUGUI scoresText;

    void Start()
    {
        ShowTable();
    }

    void ShowTable()
    {
        namesText.SetText("APODO\n");
        scoresText.SetText("SCORES\n");

        foreach (var score in MainManager.Instance.tableScore)
        {
            namesText.SetText(namesText.text + "\n" + score.name);
            scoresText.SetText(scoresText.text + "\n" + score.score);
        }
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}

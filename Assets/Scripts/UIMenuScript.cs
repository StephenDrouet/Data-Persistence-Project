using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class UIMenuScript : MonoBehaviour
{
    public GameObject errorObject;
    private TextMeshProUGUI errorText;

    public string nickName;
    private bool isNameCorrect = false;

    private void Start()
    {
        errorText = errorObject.GetComponent<TextMeshProUGUI>();
    }

    public void GetNickName(string name)
    {
        nickName = name;
        if(nickName.Length > 3 && nickName.Length < 17)
        {
            isNameCorrect = true;
        }
    }

    public void StarGame()
    {
        if (!isNameCorrect)
        {
            errorObject.SetActive(true);
            errorText.SetText("El Apodo debe contener entre 4 y 16 caracteres");
            return;
        }

        MainManager.Instance.nickName = nickName;
        SceneManager.LoadScene(1);       
    }

    public void ViewScores()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField PlayerName;
    public TMP_Text MenuHighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        DisplayHighScoreText();
    }

    // Update is called once per frame
    void Update()
    { 
       SavePlayerNameInput();
    }

    private void DisplayHighScoreText()
    {
        MenuHighScoreText.text = $"High Score : {MainManager.Instance.HighScorePlayerName} : {MainManager.Instance.HighScore}";
    }

    private void SavePlayerNameInput()
    {
        MainManager.Instance.PlayerName = PlayerName.text;
    }

    private void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    private void Exit()
    {
        MainManager.Instance.SaveHighScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void ClearHighScore()
    {
        MainManager.Instance.HighScorePlayerName= null;
        MainManager.Instance.HighScore = 0;
        DisplayHighScoreText();
        MainManager.Instance.ClearHighScore();
    }
  
}

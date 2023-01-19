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
    public TMP_Text HighScoreText;
    

    public void PlayerNameChosen(string playerName)
    {
        //MainManager.Instance.PlayerName = playerName;
    }

    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = $"High Score : {MainManager.Instance.HighScorePlayerName} : {MainManager.Instance.HighScore}";
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MainManager.Instance.SaveHighScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ClearHighScore()
    {
        MainManager.Instance.HighScorePlayerName= null;
        MainManager.Instance.HighScore = 0;
        HighScoreText.text = $"High Score : {MainManager.Instance.HighScorePlayerName} : {MainManager.Instance.HighScore}";
        MainManager.Instance.ClearHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        MainManager.Instance.PlayerName = PlayerName.text;
    }
}

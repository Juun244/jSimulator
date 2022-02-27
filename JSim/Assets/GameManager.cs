using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentGameState = GameState.menu;
    public GameObject Road;
    public GameObject PressStart;
    public GameObject inGame;
    public GameObject GameOver;
    public Text ScoreText;
    public Text BestScoreText;
    public Text OverScore;
    public Text OverBestScore;
    public int Score;
    public int BestScore;
    

    void Awake()
    {
        instance = this;
        Menu();
        BestScore = PlayerPrefs.GetInt("BestScore");
        ScoreText.text = "Score : " + Score;
        BestScoreText.text = "Best Score : " + BestScore;
    }

    public void Menu()
    {
        SetGameState(GameState.menu);
        Time.timeScale = 0f;
        Road.SetActive(true);
        PressStart.SetActive(true);
        inGame.SetActive(false);
        GameOver.SetActive(false);
    }
    public void StartGame()
    {
        SetGameState(GameState.inGame);
        Time.timeScale = 1f;
        PressStart.SetActive(false);
        inGame.SetActive(true);
        GameOver.SetActive(false);
    }

    public void Restart()
    {
        SetGameState(GameState.gameOver);
        OverScore.text = "Score : " + Score;
        OverBestScore.text = "Best Score : " + BestScore;
        PlayerPrefs.SetInt("BestScore", BestScore);
        Time.timeScale = 0f;
        GameOver.SetActive(true);
        inGame.SetActive(false);
        PressStart.SetActive(false);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("BestScore", BestScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu) { 
        }   else if (newGameState == GameState.inGame){ 
        }   else if (newGameState == GameState.gameOver) { 
        }
        currentGameState = newGameState;
    }

    public void ScoreCount(int Score)
    {
        ScoreText.text = "Score : " + Score;
        if (Score >= BestScore)
        {
            BestScore = Score;
            BestScoreText.text = "Best Score : " + BestScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}

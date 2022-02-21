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
    public GameObject GameOver;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Menu();
    }
    public void Menu()
    {
        SetGameState(GameState.menu);
        Time.timeScale = 0f;
        Road.SetActive(true);
        PressStart.SetActive(true);
        GameOver.SetActive(false);
    }
    public void StartGame()
    {
        SetGameState(GameState.inGame);
        Time.timeScale = 1f;
        PressStart.SetActive(false);
        GameOver.SetActive(false);
    }

    public void Restart()
    {
        SetGameState(GameState.gameOver);
        Time.timeScale = 0f;
        GameOver.SetActive(true);
        PressStart.SetActive(false);
    }

    public void Reset()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}

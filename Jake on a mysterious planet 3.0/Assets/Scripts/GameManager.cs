using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu, inGame, gameOver, inGameMenu
}
public class GameManager : MonoBehaviour
{
    public GameState currentGameState;
    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;
    public Canvas inGameMenuCanvas;
    public Canvas backgroundGameOverCanvas;
    public static GameManager instance;
    public int collectedCoins = 0;
    GameObject camera;
    //GameObject player;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentGameState = GameState.menu;

    }

    private void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            StartGame();
            //Debug.Log("Started");
        }
    }

    public void StartGame()
    {
        PlayerController.instancePlayer.StartGame();
        SetGameState(GameState.inGame);
        //PlayerStatus(currentGameState);
        
        CameraController(currentGameState);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
        CameraController(currentGameState);
        //PlayerStatus(currentGameState);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.inGameMenu);
        CameraController(currentGameState);
        //PlayerStatus(currentGameState);
    }

    void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            inGameMenuCanvas.enabled = false;
            backgroundGameOverCanvas.enabled = true;
        }
        else if (newGameState == GameState.inGame)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
            inGameMenuCanvas.enabled = false;
            backgroundGameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
            inGameMenuCanvas.enabled = false;
            backgroundGameOverCanvas.enabled = true;
        }
        else if(newGameState == GameState.inGameMenu)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            inGameMenuCanvas.enabled = true;
            backgroundGameOverCanvas.enabled = true;
        }
        currentGameState = newGameState;
    }

    public void CoinCollected()
    {
        collectedCoins++;
    }

    public void RestartGame()
    {
        for(int i=0;i< LevelGenerator.instanceLevel.pieces.Count; i++)
        {
            Destroy(LevelGenerator.instanceLevel.pieces[i].gameObject);
        }
        LevelGenerator.instanceLevel.pieces.Clear();
        collectedCoins = 0;
        
        LevelGenerator.instanceLevel.GenerateInitialPieces();
        StartGame();
    }

    private void CameraController(GameState currentState)
    {
        camera = GameObject.Find("Main Camera");
        CameraFollow follow = camera.GetComponent<CameraFollow>();
        
        if (currentState == GameState.gameOver||currentState==GameState.inGameMenu)
        {
            follow.enabled = false;
        }
        else
        {
            follow.enabled = true;
        }
    }
    /*private void PlayerStatus(GameState playerState)
    {
        player = GameObject.Find("Player");
        if (playerState == GameState.gameOver || playerState == GameState.inGameMenu)
        {
            player.SetActive(false);
        }
        else
        {
            player.SetActive(true);
        }
    }*/
}

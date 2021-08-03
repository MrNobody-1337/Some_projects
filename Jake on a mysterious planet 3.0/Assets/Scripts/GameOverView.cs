using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    public Text scoreLabel;
    public Text coinsLabel;
     

    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.gameOver)
        {
            coinsLabel.text = GameManager.instance.collectedCoins.ToString();
            scoreLabel.text = PlayerController.instancePlayer.GetDistance().ToString("f0");
            //highscoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
        }
    }
}

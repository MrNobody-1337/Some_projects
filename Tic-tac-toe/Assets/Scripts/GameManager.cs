using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public enum Players
{
    zero, cross
}
public class GameManager : MonoBehaviour
{
    private Players currentPlayer;
    public static GameManager instance;
    public List<GameObject> playerSprites = new List<GameObject>(2);
    public List<GameObject> playerSpritesInGame = new List<GameObject>(9);
    private static int[] winList = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
    private int clicks = 0;

    public Canvas crossVictoryCanvas;
    public Canvas zeroVictoryCanvas;
    public Canvas tieCanvas;

    public Canvas button3ZeroCanavas;
    public Canvas button3CrossCanvas;
    public Canvas button2CrossCanvas;
    public Canvas button4CrossCanvas;
    public Canvas button5CrossCanvas;
    public Canvas button6CrossCanvas;
    public Canvas button7CrossCanvas;
    public Canvas button8CrossCanvas;
    public Canvas button9CrossCanvas;
    public Canvas button1CrossCanvas;
    public Canvas button1ZeroCanvas;
    public Canvas button2ZeroCanvas;
    public Canvas button4ZeroCanvas;
    public Canvas button5ZeroCanvas;
    public Canvas button6ZeroCanvas;
    public Canvas button7ZeroCanvas;
    public Canvas button8ZeroCanvas;
    public Canvas button9ZeroCanvas;

    GameObject[] buttons = new GameObject[9];
    Vector3[] startingPositions = new Vector3[9];

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GetButtonsStartingPositions();
        StartGame();
    }
    private void StartGame()
    {
        currentPlayer = Players.cross;
        CleanTheField();
    }
    public void RestartGame()
    {
        for(int i=0; i < winList.Length; i++)
        {
            winList[i] = -1;
        }
        clicks = 0;
        ButtonsBack();
        StartGame();
    }
    private void MoveButton(int numberOfButton)
    {
        buttons[numberOfButton].transform.position = startingPositions[numberOfButton] + new Vector3(0, 1000, 0);
    }
    private void GetButtonsStartingPositions()
    {
        for(int i=0; i < buttons.Length; i++)
        {
            buttons[i] = GameObject.Find($"button{i+1}");
            startingPositions[i] = buttons[i].transform.position;
        }
    }
    private void ButtonsBack()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.position = startingPositions[i];
        }
    }
    private void CleanTheField()
    {
        tieCanvas.enabled = false;
        crossVictoryCanvas.enabled = false;
        zeroVictoryCanvas.enabled = false;
        button1CrossCanvas.enabled = false;
        button1ZeroCanvas.enabled = false;
        button3CrossCanvas.enabled = false;
        button2CrossCanvas.enabled = false;
        button4CrossCanvas.enabled = false;
        button5CrossCanvas.enabled = false;
        button6CrossCanvas.enabled = false;
        button7CrossCanvas.enabled = false;
        button8CrossCanvas.enabled = false;
        button9CrossCanvas.enabled = false;
        button3ZeroCanavas.enabled = false;
        button2ZeroCanvas.enabled = false;
        button4ZeroCanvas.enabled = false;
        button5ZeroCanvas.enabled = false;
        button6ZeroCanvas.enabled = false;
        button7ZeroCanvas.enabled = false;
        button8ZeroCanvas.enabled = false;
        button9ZeroCanvas.enabled = false;
    }
    private void ItsATie()
    {
        tieCanvas.enabled = true;
    }

    private void ChangePlayers(Players player)
    {
        if(player == Players.zero)
        {
            currentPlayer = Players.cross;
            //Debug.Log("Player changed to cross");
        }
        else
        {
            currentPlayer = Players.zero;
            //Debug.Log("Player changed to zero");
        }
    }

    private bool Win()
    {
        if (winList[0] == winList[1] && winList[1] == winList[2] && winList[0]!=-1) return true;
        if (winList[3] == winList[4] && winList[4] == winList[5] && winList[3] != -1) return true;
        if (winList[6] == winList[7] && winList[7] == winList[8] && winList[6] != -1) return true;
        if (winList[0] == winList[3] && winList[3] == winList[6] && winList[0] != -1) return true;
        if (winList[1] == winList[4] && winList[4] == winList[7] && winList[1] != -1) return true;
        if (winList[2] == winList[5] && winList[5] == winList[8] && winList[2] != -1) return true;
        if (winList[0] == winList[4] && winList[4] == winList[8] && winList[0] != -1) return true;
        if (winList[2] == winList[4] && winList[4] == winList[6] && winList[2] != -1) return true;
        return false;
    }
    private void Congrats(Players winner)
    {
        switch (winner)
        {
            case Players.cross:
                crossVictoryCanvas.enabled = true;
                break;
            case Players.zero:
                zeroVictoryCanvas.enabled = true;
                break;
        }
    }
    public void ButtonClicked(int button)
    {
        switch (button)
        {
            case 1:
                if (currentPlayer == Players.cross)
                {
                    button1CrossCanvas.enabled = true;
                    winList[0] = (int)Players.cross;
                }
                else
                {
                    button1ZeroCanvas.enabled = true;
                    winList[0] = (int)Players.zero;
                }
                break;
            case 2:
                if (currentPlayer == Players.cross)
                {
                    button2CrossCanvas.enabled = true;
                    winList[1] = (int)Players.cross;
                }
                else
                {
                    button2ZeroCanvas.enabled = true;
                    winList[1] = (int)Players.zero;
                }
                break;
            case 3:
                if (currentPlayer == Players.cross)
                {
                    button3CrossCanvas.enabled = true;
                    winList[2] = (int)Players.cross;
                }
                else
                {
                    button3ZeroCanavas.enabled = true;
                    winList[2] = (int)Players.zero;
                }
                break;
            case 4:
                if (currentPlayer == Players.cross)
                {
                    button4CrossCanvas.enabled = true;
                    winList[3] = (int)Players.cross;
                }
                else
                {
                    button4ZeroCanvas.enabled = true;
                    winList[3] = (int)Players.zero;
                }
                break;
            case 5:
                if (currentPlayer == Players.cross)
                {
                    button5CrossCanvas.enabled = true;
                    winList[4] = (int)Players.cross;
                }
                else
                {
                    button5ZeroCanvas.enabled = true;
                    winList[4] = (int)Players.zero;
                }
                break;
            case 6:
                if (currentPlayer == Players.cross)
                {
                    button6CrossCanvas.enabled = true;
                    winList[5] = (int)Players.cross;
                }
                else
                {
                    button6ZeroCanvas.enabled = true;
                    winList[5] = (int)Players.zero;
                }
                break;
            case 7:
                if (currentPlayer == Players.cross)
                {
                    button7CrossCanvas.enabled = true;
                    winList[6] = (int)Players.cross;
                }
                else
                {
                    button7ZeroCanvas.enabled = true;
                    winList[6] = (int)Players.zero;
                }
                break;
            case 8:
                if (currentPlayer == Players.cross)
                {
                    button8CrossCanvas.enabled = true;
                    winList[7] = (int)Players.cross;
                }
                else
                {
                    button8ZeroCanvas.enabled = true;
                    winList[7] = (int)Players.zero;
                }
                break;
            case 9:
                if (currentPlayer == Players.cross)
                {
                    button9CrossCanvas.enabled = true;
                    winList[8] = (int)Players.cross;
                }
                else
                {
                    button9ZeroCanvas.enabled = true;
                    winList[8] = (int)Players.zero;
                }
                break;
        }
        MoveButton(button - 1);
        clicks++;
        if (Win())
        {
            Congrats(currentPlayer);
        }
        else if (!Win() && clicks == 9)
        {
            ItsATie();
        }
        ChangePlayers(currentPlayer);
    }
}

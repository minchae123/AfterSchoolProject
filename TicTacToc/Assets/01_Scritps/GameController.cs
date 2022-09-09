using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Player
{
    public Image panel;
    public TMP_Text text;
    public Button button;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}


public class GameController : MonoBehaviour
{
    public TMP_Text[] buttonList;
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;
    public GameObject restartBtn;
    public GameObject textInfo;

    private int moveCount;

    private string playerSide;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;


    private void Awake()
    {
        SetGameControllerRefereneOnButtons();
        gameOverPanel.SetActive(false);
        restartBtn.SetActive(false);
        moveCount = 0;
        SetPlayerColors(playerX, playerO);
    }

    void SetGameControllerRefereneOnButtons()
    {
        for(int i = 0; i<buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void StartGame()
    {
        textInfo.SetActive(false);
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        if(playerSide == "X")
        {
            SetPlayerColors(playerX,playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
    }

    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if(playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }

        StartGame();
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    public void EndTurn()
    {
        moveCount++;
        if(CheckMatch())
        {
            GameOver(playerSide);
        }

        if (moveCount >= 9)
        {
            GameOver("draw");
        }

        ChangeSides();
    }

    private bool CheckWin(int i, int j, int k)
    {
        bool matched = (buttonList[i].text == playerSide && buttonList[j].text == playerSide && buttonList[k].text == playerSide);

        return matched;
    }

    private bool CheckMatch()
    {
        return CheckWin(0, 1, 2) || CheckWin(3, 4, 5) || CheckWin(6, 7, 8) ||
               CheckWin(0, 3, 6) || CheckWin(1, 4, 7) || CheckWin(2, 5, 8) ||
               CheckWin(0, 4, 8) || CheckWin(2, 4, 6);
    }

    void GameOver(string winningPlayer)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        gameOverPanel.SetActive(true);
        if (winningPlayer == "draw")
        {
            gameOverText.text = "Draw!";
        }
        else
        {
            gameOverText.text = winningPlayer + " Win!";
        }

        restartBtn.SetActive(true);
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartBtn.SetActive(false);

        SetPlayerColors(playerX, playerO);
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
            buttonList[i].GetComponentInParent<Button>().interactable = true;
        }
    }
}

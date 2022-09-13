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
    public bool isPlayerMove;

    private int moveCount;

    private string playerSide;
    private string computerSide;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
    public GameObject textInfo;
    
    public float delay;

    public LineRenderer lineRenderer;

    private void Awake()
    {
        SetGameControllerRefereneOnButtons();
        gameOverPanel.SetActive(false);
        restartBtn.SetActive(false);
        moveCount = 0;
        SetPlayerColors(playerX, playerO);
        isPlayerMove = true;
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        if(!isPlayerMove)
        delay += delay * Time.deltaTime;
        if(delay >= 100)
        {
            int v = Random.Range(0, 9);
            if (buttonList[v].GetComponentInParent<Button>().interactable)
            {
                buttonList[v].text = GetComputerSide();
                buttonList[v].GetComponentInParent<Button>().interactable = false;
                EndTurn();
            }
        }
    }

    void DrawLine(int i, int k)
    {
        lineRenderer.SetPosition(0, 
            new Vector3(buttonList[i].transform.position.x, 
            buttonList[i].transform.position.y, -9));

        lineRenderer.SetPosition(1,
            new Vector3(buttonList[k].transform.position.x,
            buttonList[k].transform.position.y, -9));

        Color color = (playerSide.Equals("X")) ? Color.green : Color.red;
        color.a = .5f;
        lineRenderer.startColor = color;
        lineRenderer.endColor = Color.white;

        lineRenderer.enabled = true;
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
        SetBoardInteractable(true);
        SetPlayerButtons(false);
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public string GetComputerSide()
    {
        return computerSide;
    }

    public void ChangeSides()
    {
        //playerSide = (playerSide == "X") ? "O" : "X";
        isPlayerMove = (isPlayerMove == true) ? false : true;
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
            computerSide = "O";
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            computerSide = "X";
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
        delay = 10;
        if(CheckMatch(playerSide))
        {
            GameOver(playerSide);
        }

        if (CheckMatch(computerSide))
        {
            GameOver(computerSide);
        }

        if (moveCount >= 9)
        {
            GameOver("draw");
        }

        ChangeSides();
    }

    private bool CheckWin(int i, int j, int k, string turn)
    {
        bool matched = (buttonList[i].text == turn && buttonList[j].text == turn && buttonList[k].text == turn);

        if (matched)
        {
            DrawLine(i, k);
        }

        return matched;
    }

    private bool CheckMatch(string turn)
    {
        return CheckWin(0, 1, 2, turn) || CheckWin(3, 4, 5, turn) || CheckWin(6, 7, 8, turn) ||
               CheckWin(0, 3, 6, turn) || CheckWin(1, 4, 7, turn) || CheckWin(2, 5, 8, turn) ||
               CheckWin(0, 4, 8, turn) || CheckWin(2, 4, 6, turn);
    }

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);
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
        SetPlayerButtons(true);
        SetBoardInteractable(true);

        isPlayerMove = true;

        SetPlayerColors(playerX, playerO);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }

        lineRenderer.enabled = false;
    }

    public void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerButtons(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI buttonText;
    public string playerSide;
    private GameController gameController;

    public void SetGameControllerReference(GameController gameController)
    {
        this.gameController = gameController;
    }

    public void SetSpace()
    {
        if(gameController.isPlayerMove == true)
        {
            buttonText.text = gameController.GetPlayerSide();
            button.interactable = false;
            gameController.EndTurn();
        }
    }
}

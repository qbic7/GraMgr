using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour {

    [SerializeField] private Text textTurn, textPlayerTurn;
    private int turn = 1, move = 1, firstMove;
    private bool playerTurn, turnChanged = false;

    public int getTurn()
    {
        return turn;
    }

    public int getMove()
    {
        return move;
    }

    public bool getPlayerTurn()
    {
        return playerTurn;
    }

    public bool getTurnChanged()
    {
        return turnChanged;
    }

    public void setTurnChanged(bool value)
    {
        turnChanged = value;
    }

    public void nextTurn()
    {
        turn++;
        textTurn.text = "Turn: " + turn;
        turnChanged = true;
    }

    public void switchMove()
    {
        playerTurn = !playerTurn;
        move++;
        if(move % 2 == 1)
        {
            nextTurn();
        }
        displayWhoTurnText();
    }

    public void displayWhoTurnText()
    {
        if (playerTurn)
        {
            textPlayerTurn.text = "Player's turn";
        }
        else
        {
            textPlayerTurn.text = "CPU's turn";
        }
    }

    private void Awake()
    {
        firstMove = Random.Range(0, 2);

        if (firstMove == 0)
        {
            playerTurn = true;
        }
        else if (firstMove == 1)
        {
            playerTurn = false;
        }
    }

    // Use this for initialization
    void Start () {
        textTurn.text = "Turn: " + turn;

        if(playerTurn)
        {
            textPlayerTurn.text = "Player's turn";
        }
        else
        {
            textPlayerTurn.text = "CPU's turn";
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    //singleton variable
    public static ScoreManager Instance;

    // Score tracking
    private int playerOneScore, playerTwoScore;
    [SerializeField] private Text playerOneScoreText, playerTwoScoreText;
    [SerializeField] int noOfPlayers = 2;
    const int Player_One_Index = 0;

    void Awake()
    {
        if (Instance)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }

        playerOneScore = 0;
        playerTwoScore = 0;
    }

    // Update the player's score
    public void UpdatePlayerScore(int player)
    {
        if (player == Player_One_Index)
        {
            playerTwoScore++;
            playerTwoScoreText.text = playerTwoScore.ToString();
        } else
        {
            playerOneScore++;
            playerOneScoreText.text = playerOneScore.ToString();
        }
    }
}

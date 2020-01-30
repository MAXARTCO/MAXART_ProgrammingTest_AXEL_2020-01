using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private int playerGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball")) ball.Reset();
        ScoreManager.Instance.UpdatePlayerScore(playerGoal);
    }
}

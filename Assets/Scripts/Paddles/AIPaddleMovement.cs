using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddleMovement : PaddleMovement
{
    // Losing track of ball position
    [SerializeField] float findBallTimeMin, findBallTimeMax;
    float findBallTimer;

    // Randomness to the balls position
    [SerializeField] float ballPosMin, ballPosMax; 

    // Next location to get to
    float nextPos;

    private void Start()
    {
        findBallTimer = 0;
    }


    void Update()
    {
        getBallPos();

        MovePaddle(nextPos - transform.position.y);
    }

    private void getBallPos()
    {
        if (findBallTimer < Time.time)
        {
            nextPos = GameObject.FindGameObjectWithTag("Ball").transform.position.y + Random.Range(ballPosMin, ballPosMax);
            findBallTimer = Time.time + Random.Range(findBallTimeMin, findBallTimeMax);
        }
    }


}

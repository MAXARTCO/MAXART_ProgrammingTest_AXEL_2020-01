using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PaddleMovement
{

    // Update is called once per frame
    void Update()
    {
        AnalyzeInput();
    }

    /// <summary>
    /// Analyze input from player, runs logic to move paddle
    /// </summary>
    private void AnalyzeInput()
    {
        float move = 0;
        if (Input.GetKey(KeyCode.W)) move += speed;
        if (Input.GetKey(KeyCode.S)) move -= speed;

        MovePaddle(move);
    }
}

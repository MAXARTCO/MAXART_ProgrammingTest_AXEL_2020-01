using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PaddleMovement
{
    [SerializeField] private float speed;
    [SerializeField] private float upperBound, lowerbound;

    // Update is called once per frame
    void Update()
    {
        AnalyzeInput();
    }

    public float GetLastMove() => lastMove;

    /// <summary>
    /// Analyze input from player, runs logic to move paddle
    /// </summary>
    private void AnalyzeInput()
    {
        Vector2 move = new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.W)) move.y += speed;
        if (Input.GetKey(KeyCode.S)) move.y -= speed;

        MovePaddle(move);
    }

    private void MovePaddle(Vector2 move)
    {
        Vector3 position = GetComponent<Transform>().position + new Vector3(move.x, move.y, 0) * Time.deltaTime;

        // Make sure we don't go off screen
        position.y = Mathf.Clamp(position.y, lowerbound, upperBound);

        SetNewPosition(position.y);

        transform.position = position;
    }
}

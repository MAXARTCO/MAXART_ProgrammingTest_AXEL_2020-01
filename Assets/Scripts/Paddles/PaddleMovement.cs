﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // The last move input to the paddle
    protected float lastMove;

    // The position of the paddle last frame
    private float lastPosition;

    [SerializeField] protected float speed;
    [SerializeField] protected float upperBound, lowerbound;

    private void Start()
    {
    }

    /// <summary>
    /// Set lastMove and lastPosition based on the new input position
    /// </summary>
    protected void SetNewPosition(float newPosition)
    {
        lastMove = lastPosition - newPosition;
        lastPosition = newPosition;
    }

    public float GetLastMove() => lastMove;

    protected void MovePaddle(float move)
    {
        Vector3 position = GetComponent<Transform>().position + new Vector3(0, move, 0) * Time.deltaTime;

        // Make sure we don't go off screen
        position.y = Mathf.Clamp(position.y, lowerbound, upperBound);

        SetNewPosition(position.y);

        transform.position = position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // The last move input to the paddle
    protected float lastMove;

    // The position of the paddle last frame
    private float lastPosition;

    /// <summary>
    /// Set lastMove and lastPosition based on the new input position
    /// </summary>
    protected void SetNewPosition(float newPosition)
    {
        lastMove = lastPosition - newPosition;
        lastPosition = newPosition;
    }

    public float GetLastMove() => lastMove;
}

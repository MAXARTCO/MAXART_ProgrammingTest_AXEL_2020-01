using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Ball movement settings
    [SerializeField] private float ballSpeed, paddleMultiplier, resetTime;
    [SerializeField] Rigidbody2D rb;

    Vector3 lastVel;

    private void Start()
    {
        ThrowBall();
    }

    private void ThrowBall()
    {
        rb.velocity = Vector2.left * ballSpeed;
        lastVel = rb.velocity.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Calculate the ball direction reflected along the hit normal
        ContactPoint2D contactPoint = collision.GetContact(0);
        Vector2 reflect = CalculateReflection(lastVel, contactPoint.normal);

        // Add velocity from the paddle's movement
        PaddleMovement pmove = collision.collider.GetComponent<PaddleMovement>();
        if (pmove != null) reflect.y += -pmove.GetLastMove() * paddleMultiplier;

        // Set the new velocity
        rb.velocity = reflect.normalized * ballSpeed;
        lastVel = rb.velocity.normalized;
    }

    /// <summary>
    /// Calculates the reflection of a vector
    /// </summary>
    Vector2 CalculateReflection(Vector2 direction, Vector2 normal) => direction - 2 * (Vector2.Dot(normal, direction)) * normal; 

    public void Reset()
    {
        StopCoroutine(nameof(ResetRoutine));
        StartCoroutine(nameof(ResetRoutine));
    }

    private IEnumerator ResetRoutine()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        yield return new WaitForSeconds(resetTime);
        ThrowBall();
    }
}

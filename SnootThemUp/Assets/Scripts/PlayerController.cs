using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static float horizontalInput, speed, xLimit;

    void Start()
    {
        speed = 15f;
        xLimit = 20f;
    }

    void FixedUpdate()
    {
        float xPos, clamp;

        // Move the player
        transform.Translate(new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime);

        // If out of bounds, fix its position
        xPos = transform.position.x;
        clamp = (xPos < -xLimit) ? -xLimit : (xPos > xLimit) ? xLimit : xPos;
        transform.position = new Vector3(clamp, transform.position.y, transform.position.z);
    }

    void OnMove(InputValue axisValue)
    {
        // Go LEFT (left or up input) and go RIGHT (right or down input)
        Vector2 movementVector = axisValue.Get<Vector2>();
        horizontalInput = movementVector.x + -movementVector.y;
        if (horizontalInput < -1f) horizontalInput = -1f;
        else if (horizontalInput > 1f) horizontalInput = 1f;
    }
}

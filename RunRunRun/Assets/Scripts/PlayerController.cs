using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static Rigidbody rb;
    private static float jumpForce;
    private static bool canJump;
    public bool gameOver;

    void Awake()
    {
        Physics.gravity = new Vector3(0f, -50f, 0f);
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        jumpForce = 20f;
        gameOver = false;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (canJump && ctx.started)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
        }
        else
            canJump = true;
    }
}

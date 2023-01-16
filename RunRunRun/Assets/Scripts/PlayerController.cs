using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static Rigidbody rb;
    private static Animator anim;
    private static float jumpForce;
    private static bool canJump;
    public bool gameOver;

    void Awake()
    {
        Physics.gravity = new Vector3(0f, -50f, 0f);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        jumpForce = 20f;
        gameOver = false;
    }

    void LateUpdate()
    {
        // If the player jumps right before the game over occurs, they can end up on top of the obstacle, so put them back onto the ground
        if (gameOver)
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (canJump && ctx.started)
        {
            anim.SetTrigger("Jump_trig");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            GameOver();
        else
            canJump = true;
    }

    private void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            canJump = false;
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static Rigidbody rb;
    private static float jumpForce;
    private static bool canJump;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        jumpForce = 10f;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (canJump && ctx.started)
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter()
    {
        canJump = true;
    }
}

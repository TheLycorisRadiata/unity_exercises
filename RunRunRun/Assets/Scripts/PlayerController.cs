using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;
    [SerializeField] private ParticleSystem explosionParticle, dirtParticle;
    [SerializeField] private AudioClip jumpSound, crashSound;
    private static Rigidbody rb;
    private static Animator anim;
    private static AudioSource audioSource;
    private static float jumpForce;
    private static bool canJump;

    void Awake()
    {
        Physics.gravity = new Vector3(0f, -50f, 0f);
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(jumpSound, 1f);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dirtParticle.Stop();
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            GameOver();
        else
        {
            dirtParticle.Play();
            canJump = true;
        }
    }

    private void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            canJump = false;
            explosionParticle.Play();
            dirtParticle.Stop();
            audioSource.PlayOneShot(crashSound, 1f);
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private static PlayerController playerControllerScript;
    [SerializeField] private float speed;

    void Awake()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        if (!playerControllerScript.gameOver)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}

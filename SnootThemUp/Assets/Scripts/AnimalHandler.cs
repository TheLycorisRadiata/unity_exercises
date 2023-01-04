using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHandler : MonoBehaviour
{
    private static float zLimit;
    private float speed;

    void Start()
    {
        zLimit = -10f;
        speed = transform.localScale.x < 10f ? Random.Range(10f, 15f) : Random.Range(7f, 10f);
    }

    void FixedUpdate()
    {
        // Move forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Destroy when out of bounds
        if (transform.position.z < zLimit)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Steak"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

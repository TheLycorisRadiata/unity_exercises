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
        speed = Random.Range(10f, 15f);
    }

    void FixedUpdate()
    {
        // Move forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Destroy when out of bounds
        if (transform.position.z < zLimit)
            Destroy(gameObject);
    }
}

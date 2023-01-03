using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHandler : MonoBehaviour
{
    private static float speed, zLimit;

    void Start()
    {
        speed = 25f;
        zLimit = -10f;
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

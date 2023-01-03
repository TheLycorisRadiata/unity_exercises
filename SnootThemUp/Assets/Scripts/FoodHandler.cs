using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    private static float speed, zLimit;

    void Start()
    {
        speed = 30f;
        zLimit = 30f;
    }

    void FixedUpdate()
    {
        // Move forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Destroy when out of bounds
        if (transform.position.z > zLimit)
            Destroy(gameObject);
    }
}

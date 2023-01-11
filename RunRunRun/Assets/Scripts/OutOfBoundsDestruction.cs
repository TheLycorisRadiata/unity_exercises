using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsDestruction : MonoBehaviour
{
    private static float xLimit;

    void Start()
    {
        xLimit = 20f;
    }

    void FixedUpdate()
    {
        if (transform.position.x < -xLimit)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private static float minSpeed, maxSpeed;
    private static float maxTorque;
    private static float xRange;
    private static float ySpawnPos;
    private Rigidbody rb;

    void Awake()
    {
        minSpeed = 15f;
        maxSpeed = 20f;
        maxTorque = 10f;
        xRange = 4f;
        ySpawnPos = -6f;
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private static float repeatWidth;
    private static Vector3 startPos;

    void Awake()
    {
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
            transform.position = startPos;
    }
}

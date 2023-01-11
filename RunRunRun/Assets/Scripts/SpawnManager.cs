using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static PlayerController playerControllerScript;
    [SerializeField] private GameObject[] obstaclePrefabs;
    private static Vector3 pos;
    private static float startDelay, repeatRate;

    void Awake()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        pos = new Vector3(35f, 0f, 0f);
        startDelay = 1f;
        repeatRate = 2f;

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        if (!playerControllerScript.gameOver)
            Instantiate(obstaclePrefabs[index], pos, obstaclePrefabs[index].transform.rotation);
    }
}

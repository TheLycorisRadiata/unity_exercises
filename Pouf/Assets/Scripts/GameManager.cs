using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static float spawnRate;
    [SerializeField] private List<GameObject> targets;

    void Start()
    {
        spawnRate = 1f;
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        int index;

        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}

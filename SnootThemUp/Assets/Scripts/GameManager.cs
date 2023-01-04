using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabAnimals;
    private static float xPosLimit, zPos;
    private static Quaternion rotation;

    void Start()
    {
        xPosLimit = 20f;
        zPos = 20f;
        rotation = prefabAnimals[0].transform.rotation;
        StartCoroutine(SpawnAnimal());
    }

    private IEnumerator SpawnAnimal()
    {
        int index;
        Vector3 pos;

        while (true)
        {
            yield return new WaitForSeconds(2f);
            index = Random.Range(0, prefabAnimals.Length);
            pos = new Vector3(Random.Range(-xPosLimit, xPosLimit), 0f, zPos);
            Instantiate(prefabAnimals[index], pos, rotation);
        }
    }
}

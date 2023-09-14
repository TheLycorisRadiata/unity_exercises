using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    private enum SpawnOrigin
    {
        Top,
        Left,
        Right
    }

    [SerializeField] private GameObject[] _prefabAnimals;

    private void Start()
    {
        InvokeRepeating("SpawnAnimal", 2f, 2f);
    }

    private void SpawnAnimal()
    {
        int index = Random.Range(0, _prefabAnimals.Length);
        int spawnOrigin = Random.Range(0, 3);
        Vector3 pos;
        Quaternion rot;

        if (spawnOrigin == (int)SpawnOrigin.Top)
        {
            pos = new Vector3(Random.Range(-20f, 20f), 0f, 25f);
            rot = Quaternion.Euler(0, 180f, 0);
        }
        else if (spawnOrigin == (int)SpawnOrigin.Left)
        {
            pos = new Vector3(-25f, 0f, Random.Range(3f, 23f));
            rot = Quaternion.Euler(0, 90f, 0);
        }
        else
        {
            pos = new Vector3(25f, 0f, Random.Range(3f, 23f));
            rot = Quaternion.Euler(0, 270f, 0);
        }

        Instantiate(_prefabAnimals[index], pos, rot);
    }
}

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private float _spawnRange = 9f;

    private void Start()
    {
        Instantiate(_enemyPrefab, GetRandomPos(), _enemyPrefab.transform.rotation);
    }

    private Vector3 GetRandomPos()
    {
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
        return new Vector3(spawnPosX, 0f, spawnPosZ);
    }
}

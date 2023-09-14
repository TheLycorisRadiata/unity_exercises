using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _ballPrefabs;

    private float _spawnLimitXLeft = -22f;
    private float _spawnLimitXRight = 7f;
    private float _spawnPosY = 30f;

    private float _startDelay = 1f;
    private float _spawnIntervalMin = 3f;
    private float _spawnIntervalMax = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomBall", _startDelay, Random.Range(_spawnIntervalMin, _spawnIntervalMax));
    }

    // Spawn random ball at random x position at top of play area
    private void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        int index = Random.Range(0, _ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(_spawnLimitXLeft, _spawnLimitXRight), _spawnPosY, 0f);

        // Instantiate ball at random spawn location
        Instantiate(_ballPrefabs[index], spawnPos, _ballPrefabs[index].transform.rotation);
    }

}

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _powerupPrefab;
    [SerializeField] private Transform _player;

    private int _enemyCount = 0;
    private int _waveCount = 1;
    private float _spawnRangeX = 10f;
    private float _spawnZMin = 15f;
    private float _spawnZMax = 25f;

    private void LateUpdate()
    {
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (_enemyCount == 0)
        {
            SpawnPowerups();
            SpawnEnemyWave(_waveCount);
        }
    }

    private void SpawnPowerups()
    {
        // Make powerups spawn at player end
        Vector3 powerupSpawnOffset = new Vector3(0f, 0f, -15f);
        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0)
            Instantiate(_powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, _powerupPrefab.transform.rotation);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        int i;
        for (i = 0; i < enemiesToSpawn; ++i)
            Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);

        ++_waveCount;
        ResetPlayerPosition();
    }

    private Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-_spawnRangeX, _spawnRangeX);
        float zPos = Random.Range(_spawnZMin, _spawnZMax);
        return new Vector3(xPos, 0f, zPos);
    }

    // Move player back to position in front of own goal
    private void ResetPlayerPosition()
    {
        _player.position = new Vector3(0f, 1f, -7f);
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}

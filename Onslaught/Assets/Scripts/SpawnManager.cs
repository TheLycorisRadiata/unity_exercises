using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _strengthPowerupPrefab;
    [SerializeField] private GameObject _firePowerupPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    private float _spawnRange = 9f;
    private int _waveNumber = 1;

    private void Update()
    {
        if (FindObjectsOfType<Enemy>().Length == 0)
        {
            SpawnPowerup();
            SpawnEnemyWave(_waveNumber++);
        }
    }

    private void SpawnPowerup()
    {
        GameObject powerup = _waveNumber % 2 == 0 ? _firePowerupPrefab : _strengthPowerupPrefab;
        Instantiate(powerup, GetRandomPos(), powerup.transform.rotation);
    }

    private void SpawnEnemyWave(int nbrEnemiesToSpawn)
    {
        int i;
        for (i = 0; i < nbrEnemiesToSpawn; ++i)
            Instantiate(_enemyPrefab, GetRandomPos(), _enemyPrefab.transform.rotation);
    }

    private Vector3 GetRandomPos()
    {
        float spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        float spawnPosZ = Random.Range(-_spawnRange, _spawnRange);
        return new Vector3(spawnPosX, 0f, spawnPosZ);
    }
}

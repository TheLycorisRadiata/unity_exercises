using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectPrefabs;
    private float _spawnDelay = 2f;
    private float _spawnInterval = 1.5f;
    private PlayerController _playerControllerScript;

    private void Awake()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Start()
    {
        InvokeRepeating("SpawnObjects", _spawnDelay, _spawnInterval);
    }

    private void SpawnObjects()
    {
        Vector3 spawnLocation;
        int index;

        if (_playerControllerScript.gameOver)
            return;
        
        spawnLocation = new Vector3(30f, Random.Range(5f, 15f), 0f);
        index = Random.Range(0, _objectPrefabs.Length);
        Instantiate(_objectPrefabs[index], spawnLocation, _objectPrefabs[index].transform.rotation);
    }
}

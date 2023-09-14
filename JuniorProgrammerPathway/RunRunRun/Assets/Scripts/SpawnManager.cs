using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePrefabs;
    private Vector3 _pos = new Vector3(35f, 0f, 0f);
    private float _startDelay = 1f;
    private float _repeatRate = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }

    private void SpawnObstacle()
    {
        int index = Random.Range(0, _obstaclePrefabs.Length);
        if (PlayerController.instance.gameOngoing)
            Instantiate(_obstaclePrefabs[index], _pos, _obstaclePrefabs[index].transform.rotation);
    }
}

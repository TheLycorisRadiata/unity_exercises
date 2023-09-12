using UnityEngine;

public class PopulateSpheres : MonoBehaviour
{
    [SerializeField] private GameObject _spherePrefab;

    private void Awake()
    {
        int i;
        GameObject sphere;
        for (i = 0; i < 30; ++i)
        {
            sphere = Instantiate(_spherePrefab, GetRandomPosition(), Quaternion.identity);
            sphere.transform.parent = transform;
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-4f, 4f), Random.Range(10f, 15f), Random.Range(-4f, 4f));
    }
}

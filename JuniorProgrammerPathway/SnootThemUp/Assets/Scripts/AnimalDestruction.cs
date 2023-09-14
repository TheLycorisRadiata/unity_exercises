using UnityEngine;

public class AnimalDestruction : MonoBehaviour
{
    private Vector3 _spawnPoint;

    private void Awake()
    {
        _spawnPoint = transform.position;
    }

    private void FixedUpdate()
    {
        if (IsOutOfBounds())
        {
            Destroy(gameObject);
            --PlayerStats.instance.lives;
            PlayerStats.instance.DisplayLives();
        }
    }

    private bool IsOutOfBounds()
    {
        return Mathf.Abs(transform.position.x) > 30f || transform.position.z < -10f;
    }
}

using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    private float _speed;

    private void Start()
    {
        // Small animals are faster than big ones 
        _speed = transform.localScale.x < 10f ? Random.Range(10f, 15f) : Random.Range(7f, 10f);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}

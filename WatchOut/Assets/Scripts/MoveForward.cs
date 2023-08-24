using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float _speed = 20f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}

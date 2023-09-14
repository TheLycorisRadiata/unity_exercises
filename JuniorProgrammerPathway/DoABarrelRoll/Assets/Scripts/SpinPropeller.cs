using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    private float _speed = 30f;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
    }
}

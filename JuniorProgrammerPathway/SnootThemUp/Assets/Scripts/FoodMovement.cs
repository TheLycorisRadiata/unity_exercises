using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    private static float _speed = 30f;

    private void FixedUpdate()
    {
        // Move forward
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}

using UnityEngine;

public class FoodDestruction : MonoBehaviour
{
    private static float _zLimit = 30f;

    private void FixedUpdate()
    {
        // Destroy when out of bounds
        if (transform.position.z > _zLimit)
            Destroy(gameObject);
    }
}

using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _leftBound = -10f;

    private void LateUpdate()
    {
        if (transform.position.x < _leftBound)
            Destroy(gameObject);
    }
}

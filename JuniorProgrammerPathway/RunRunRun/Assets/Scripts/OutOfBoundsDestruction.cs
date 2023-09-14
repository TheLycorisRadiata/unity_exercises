using UnityEngine;

public class OutOfBoundsDestruction : MonoBehaviour
{
    private float _xLimit = 20f;

    private void FixedUpdate()
    {
        if (transform.position.x < -_xLimit)
            Destroy(gameObject);
    }
}

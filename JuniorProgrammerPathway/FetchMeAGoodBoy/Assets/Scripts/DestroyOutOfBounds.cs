using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _leftLimit = -35f;
    private float _bottomLimit = -5f;

    private void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < _leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < _bottomLimit)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}

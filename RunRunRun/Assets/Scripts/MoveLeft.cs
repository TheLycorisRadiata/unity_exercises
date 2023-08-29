using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 15f;

    private void FixedUpdate()
    {
        if (PlayerController.instance.gameOngoing)
            transform.Translate(Vector3.left * _speed * PlayerController.instance.speedMultiplier * Time.deltaTime);
    }
}

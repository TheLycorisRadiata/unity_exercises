using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _offset = new Vector3(0f, 6.5f, -8.5f);

    private void LateUpdate()
    {
        transform.position = _player.position + _offset;
    }
}

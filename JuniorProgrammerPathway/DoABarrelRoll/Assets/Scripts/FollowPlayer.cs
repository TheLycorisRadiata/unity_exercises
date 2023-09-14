using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _offset = new Vector3(10f, 1f, 0f);

    private void LateUpdate()
    {
        transform.position = _player.position + _offset;
    }
}

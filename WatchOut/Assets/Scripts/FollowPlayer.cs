using UnityEngine;
using UnityEngine.InputSystem;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private InputActionReference _povSwitchValue;
    private static Vector3 _thirdPersonOffset = new Vector3(0f, 6.5f, -8.5f);
    private static Vector3 _firstPersonOffset = new Vector3(0f, 3.5f, -1f);
    private Vector3 _offset = _thirdPersonOffset;
    private bool _isThirdPerson = true;

    private void Awake()
    {
        _povSwitchValue.action.started += SwitchPOV;
    }

    private void LateUpdate()
    {
        transform.position = _player.position + _offset;
    }

    private void SwitchPOV(InputAction.CallbackContext context)
    {
        _isThirdPerson = !_isThirdPerson;
        _offset = _isThirdPerson ? _thirdPersonOffset : _firstPersonOffset;
    }
}

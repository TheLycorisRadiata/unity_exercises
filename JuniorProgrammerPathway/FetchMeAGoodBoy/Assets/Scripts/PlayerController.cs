using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _dogPrefab;
    [SerializeField] private InputActionReference _fireValue;
    private bool _canSpawnDog = true;

    private void Awake()
    {
        _fireValue.action.started += SendDog;
    }

    private void SendDog(InputAction.CallbackContext context)
    {
        if (_canSpawnDog)
            StartCoroutine(SpawnDog());
    }

    private IEnumerator SpawnDog()
    {
        Instantiate(_dogPrefab, transform.position, _dogPrefab.transform.rotation);

        _canSpawnDog = false;
        yield return new WaitForSeconds(1);
        _canSpawnDog = true;
    }
}

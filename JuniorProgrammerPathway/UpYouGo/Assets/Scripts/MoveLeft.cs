using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float _speed;
    private PlayerController _playerControllerScript;

    private void Awake()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!_playerControllerScript.gameOver)
            transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
    }
}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    [SerializeField] private int _pointValue;
    [SerializeField] private GameObject _explosionFx;
    [SerializeField] private float _timeOnScreen = 1f;
    private Rigidbody _rb;

    // The x value of the center of the left-most square
    private float _minValueX = -3.75f;
    // The y value of the center of the bottom-most square
    private float _minValueY = -3.75f;
    // The distance between the centers of squares on the game board
    private float _spaceBetweenSquares = 2.5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.position = RandomSpawnPosition();
        // Begin timer before target leaves screen
        StartCoroutine(RemoveObjectRoutine());
    }

    private void OnMouseDown()
    {
        if (!GameManager.Instance.IsGameActive)
            return;

        Destroy(gameObject);
        GameManager.Instance.UpdateScore(_pointValue);
        Explode();    
    }

    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = _minValueX + (RandomSquareIndex() * _spaceBetweenSquares);
        float spawnPosY = _minValueY + (RandomSquareIndex() * _spaceBetweenSquares);
        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0f);
        return spawnPosition;
    }

    private int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Sensor") && !gameObject.CompareTag("Bad"))
            GameManager.Instance.GameOver();
    }

    private void Explode()
    {
        Instantiate(_explosionFx, transform.position, _explosionFx.transform.rotation);
    }

    private IEnumerator RemoveObjectRoutine()
    {
        yield return new WaitForSeconds(_timeOnScreen);
        if (GameManager.Instance.IsGameActive)
            transform.Translate(Vector3.forward * 5f, Space.World);
    }
}

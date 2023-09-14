using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerHitsGround : MonoBehaviour
{
    private AudioSource _audioSource;
    private Rigidbody _rb;
    private PlayerController _playerControllerScript;

    private void Awake()
    {
        GameObject player = GameObject.Find("Player");
        _audioSource = GetComponent<AudioSource>();
        _rb = player.GetComponent<Rigidbody>();
        _playerControllerScript = player.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_playerControllerScript.gameOver)
            return;
        _rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        _audioSource.Play();
    }
}

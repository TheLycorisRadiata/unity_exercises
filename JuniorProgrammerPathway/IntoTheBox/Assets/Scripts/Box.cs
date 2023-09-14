using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Box : MonoBehaviour
{
    [SerializeField] private Text _counterText;
    [SerializeField] private Material _triggeredSphere;
    private AudioSource _audioSource;
    private int _count = 0;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Renderer>().material = _triggeredSphere;
        _audioSource.Play();
        _count += 1;
        _counterText.text = "Count: " + _count;
    }
}

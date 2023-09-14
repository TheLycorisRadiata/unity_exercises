using UnityEngine;

public class SpinObjects : MonoBehaviour
{
    [SerializeField] private float _spinSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up, _spinSpeed * Time.deltaTime);
    }
}

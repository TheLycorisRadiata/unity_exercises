using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    [SerializeField] private Camera _leftCamera;
    [SerializeField] private Camera _rightCamera;

    private void Awake()
    {
        _leftCamera.rect = new Rect(0f, 0f, 0.5f, 1f);
        _rightCamera.rect = new Rect(0.5f, 0f, 1f, 1f);
    }
}

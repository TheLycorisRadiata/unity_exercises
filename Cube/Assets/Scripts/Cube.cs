using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    
    private void Start()
    {
        transform.position = new Vector3(3f, 4f, 1f);
        transform.localScale = Vector3.one * 1.3f;

        _renderer.material.color = new Color(0.5f, 1f, 0.3f, 0.4f);
        InvokeRepeating("ChangeColorAndOpacityAtRandom", 1f, 1f);
    }
    
    private void Update()
    {
        transform.Rotate(10f * Time.deltaTime, 0f, 0f);
    }

    private void ChangeColorAndOpacityAtRandom()
    {
        _renderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}

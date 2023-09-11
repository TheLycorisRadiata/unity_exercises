using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class Swipe : MonoBehaviour
{
    private Camera cam;
    private TrailRenderer trail;
    private BoxCollider col;
    private Vector3 mousePos = Vector3.zero;
    private bool swiping = false;

    private void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
        col = GetComponent<BoxCollider>();
        col.enabled = false;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameActive)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            swiping = true;
            UpdateComponents();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            swiping = false;
            UpdateComponents();
        }
        if (swiping)
        {
            UpdateMousePosition();
        }
    }

    private void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        transform.position = mousePos;
    }

    private void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Target target = collision.gameObject.GetComponent<Target>();
        if (target)
            target.DestroyTarget();
    }
}

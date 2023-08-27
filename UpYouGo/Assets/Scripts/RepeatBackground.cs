using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
        // Establish the default starting position
        startPos = transform.position;
        // Set repeat width to half of the background
        repeatWidth = GetComponent<BoxCollider>().size.y / 2f;
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}

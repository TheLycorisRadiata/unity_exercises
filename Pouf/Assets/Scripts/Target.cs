using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private int pointValue;
    private Rigidbody rb;
    private AudioSource audioSource;
    private float minSpeed = 15f, maxSpeed = 20f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = -6f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GameObject.Find("Sounds/" + gameObject.name.Split('(')[0]).GetComponent<AudioSource>();
    }

    private void Start()
    {
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0f);
    }

    // When the user clicks on it
    private void OnMouseDown()
    {
        DestroyTarget();
    }

    public void DestroyTarget()
    {
        if (!GameManager.Instance.IsGameActive)
            return;

        Destroy(gameObject);
        audioSource.Play();
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        GameManager.Instance.UpdateScore(pointValue);
    }

    // When it collides with the sensor down below
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        // If a good target is missed by the user
        if (pointValue > 0)
            GameManager.Instance.UpdateLives(-1);
    }
}

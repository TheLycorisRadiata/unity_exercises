using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canSpawnDog;

    void Start()
    {
        canSpawnDog = true;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (canSpawnDog && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnDog());
        }
    }

    IEnumerator SpawnDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

        canSpawnDog = false;
        yield return new WaitForSeconds(1);
        canSpawnDog = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static int score;
    private static float spawnRate;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private List<GameObject> targets;

    void Start()
    {
        score = 0;
        spawnRate = 1f;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        int index;

        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}

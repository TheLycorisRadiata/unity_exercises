using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    private static int score;
    private static float spawnRate;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameoverText;
    [SerializeField] private List<GameObject> targets;

    void Start()
    {
        isGameActive = true;
        score = 0;
        spawnRate = 1f;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        int index;

        while (isGameActive)
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

    public void GameOver()
    {
        isGameActive = false;
        gameoverText.gameObject.SetActive(true);
    }
}

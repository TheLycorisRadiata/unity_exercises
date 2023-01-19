using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    private static int score;
    private static float spawnRate;
    [SerializeField] private GameObject titleScreen, gameScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameoverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private List<GameObject> targets;

    void Start()
    {
        isGameActive = false;
        spawnRate = 2f;
    }

    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);

        score = 0;
        UpdateScore(0);
        gameScreen.gameObject.SetActive(true);

        spawnRate /= difficulty;
        isGameActive = true;
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
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsGameActive { get; private set; }
    [SerializeField] private GameObject titleScreen, gameScreen, swiper;
    [SerializeField] private TextMeshProUGUI scoreText, livesText, gameoverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private AudioSource fallAudioSource, gameoverAudioSource;
    [SerializeField] private List<GameObject> targets;
    private int score = 0, lives = 1;
    private float spawnRate = 1f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void StartGame(Difficulty difficulty)
    {
        titleScreen.gameObject.SetActive(false);

        score = 0;
        UpdateScore(0);
        lives = difficulty == Difficulty.Hard ? 1 : 3;
        if (lives > 1)
        {
            UpdateLives(0);
            livesText.gameObject.SetActive(true);
        }
        if (difficulty != Difficulty.Easy)
            swiper.SetActive(false);
        gameScreen.gameObject.SetActive(true);
        IsGameActive = true;
        StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        int index;

        while (IsGameActive)
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

    public void UpdateLives(int livesToAdd)
    {
        if (lives == 0)
            return;
        lives += livesToAdd;
        livesText.text = "Lives: " + lives;
        if (lives == 0)
        {
            if (livesToAdd != 0)
                gameoverAudioSource.Play();
            GameOver();
        }
        else if (livesToAdd != 0)
            fallAudioSource.Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameOver()
    {
        IsGameActive = false;
        gameoverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsGameActive { get; private set; }
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private GameObject _titleScreen;
    [SerializeField] private Button _restartButton;
    [SerializeField] private List<GameObject> _targetPrefabs;
    private int _score;
    private float _time = 60f;
    private float _spawnRate = 1.5f;
    private float _spaceBetweenSquares = 2.5f; 
    // x value of the center of the left-most square
    private float _minValueX = -3.75f;
    // y value of the center of the bottom-most square
    private float _minValueY = -3.75f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void FixedUpdate()
    {
        if (IsGameActive)
        {
            _time -= Time.deltaTime;
            _timer.text = "Time: " + (int)_time;
            if (_time <= 0f)
                GameOver();
        }
    }

    public void StartGame(Difficulty difficulty)
    {
        _spawnRate /= (int)difficulty;
        IsGameActive = true;
        StartCoroutine(SpawnTarget());
        _score = 0;
        _time = 60f;
        UpdateScore(0);
        _titleScreen.SetActive(false);
    }

    private IEnumerator SpawnTarget()
    {
        int index;
        while (IsGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            index = Random.Range(0, _targetPrefabs.Count);

            if (IsGameActive)
                Instantiate(_targetPrefabs[index], RandomSpawnPosition(), _targetPrefabs[index].transform.rotation);
        }
    }

    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = _minValueX + (RandomSquareIndex() * _spaceBetweenSquares);
        float spawnPosY = _minValueY + (RandomSquareIndex() * _spaceBetweenSquares);
        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0f);
        return spawnPosition;
    }

    private int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        IsGameActive = false;
        _gameOverText.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

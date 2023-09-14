using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public int lives = 3;
    public int score = 0;
    [SerializeField] private TextMeshProUGUI _livesTmpro;
    [SerializeField] private TextMeshProUGUI _scoreTmpro;
    [SerializeField] private GameObject _gameOver;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);

        DisplayLives();
        DisplayScore();
    }

    private void LateUpdate()
    {
        if (lives < 1)
            GameOver();
    }

    public void DisplayLives()
    {
        _livesTmpro.text = "Lives: " + lives.ToString();
    }

    public void DisplayScore()
    {
        _scoreTmpro.text = "Score: " + score.ToString();
    }

    private void GameOver()
    {
        _gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}

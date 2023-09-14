using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HighScoreText;
    [SerializeField] private TextMeshProUGUI PaddleSpeedText;
    [SerializeField] private Slider PaddleSpeedSlider;

    private void Start()
    {
        HighScoreText.text = $"High Score: {DataManager.Instance.HighScore}";
        PaddleSpeedText.text = $"Paddle Speed: {DataManager.Instance.PaddleSpeed}";
        PaddleSpeedSlider.value = DataManager.Instance.PaddleSpeed;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        DataManager.Instance.SaveDataToDisk();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void UpdatePaddleSpeed()
    {
        float speed = (float)Math.Round(PaddleSpeedSlider.value, 2);
        DataManager.Instance.PaddleSpeed = speed;
        PaddleSpeedText.text = $"Paddle Speed: {speed}";
    }
}

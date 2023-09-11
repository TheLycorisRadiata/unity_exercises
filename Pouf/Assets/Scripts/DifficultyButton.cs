using UnityEngine;
using UnityEngine.UI;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

[RequireComponent(typeof(Button))]
public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private Difficulty difficulty;
    [SerializeField] private AudioSource audioSource;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        audioSource.Play();
        GameManager.Instance.StartGame(difficulty);
    }
}

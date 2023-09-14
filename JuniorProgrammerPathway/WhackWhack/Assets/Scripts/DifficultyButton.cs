using UnityEngine;
using UnityEngine.UI;

public enum Difficulty
{
    Easy = 1,
    Medium,
    Hard
}

[RequireComponent(typeof(Button))]
public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private Difficulty _difficulty;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        GameManager.Instance.StartGame(_difficulty);
    }
}

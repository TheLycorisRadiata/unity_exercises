using UnityEngine;
using UnityEngine.UI;

public class FeedAnimal : MonoBehaviour
{
    [SerializeField] private GameObject _fillImage;
    [SerializeField] private Slider _slider;
    private int _foodIntake = 25;

    private void Awake()
    {
        // Small animals are fed with less food
        _foodIntake = transform.localScale.x < 10f ? 50 : 34;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Steak"))
        {
            FillHungerBar();
            if (!IsHungerBarFull())
                return;
            IncreaseScore();
            Destruction(other.gameObject);
        }
    }

    private void FillHungerBar()
    {
        if (_fillImage.activeSelf == false)
        {
            _fillImage.SetActive(true);
            _slider.value += _foodIntake - 20;
        }
        else
            _slider.value += _foodIntake;
    }

    private bool IsHungerBarFull()
    {
        return _slider.value >= _slider.maxValue;
    }

    private void IncreaseScore()
    {
        ++PlayerStats.instance.score;
        PlayerStats.instance.DisplayScore();
    }

    private void Destruction(GameObject food)
    {
        Destroy(food);
        Destroy(gameObject);
    }
}

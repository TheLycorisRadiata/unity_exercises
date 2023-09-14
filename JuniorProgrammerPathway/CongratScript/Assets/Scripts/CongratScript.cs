using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CongratScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private List<string> _textToDisplay;
    private float _rotatingSpeed = 1.5f;
    private float _timeToNextText = 0f;
    private int _currentText = 0;

    private void Awake()
    {
        _textToDisplay = new List<string>();
        _textToDisplay.Add("Congratulations!");
        _textToDisplay.Add("All Errors Fixed");
        _text.text = _textToDisplay[0];
    }

    private void Update()
    {
        _timeToNextText += Time.deltaTime;

        if (_timeToNextText > _rotatingSpeed)
        {
            _timeToNextText = 0f;
            
            ++_currentText;
            if (_currentText >= _textToDisplay.Count)
                _currentText = 0;

            _text.text = _textToDisplay[_currentText];
        }
    }
}
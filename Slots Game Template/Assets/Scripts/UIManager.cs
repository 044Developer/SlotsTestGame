using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Globalization;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _spinnButton;
    [SerializeField] private TextMeshProUGUI _locationText;
    [SerializeField] private TextMeshProUGUI _localTimeText;

    private void Start()
    {
        _spinnButton.onClick.AddListener(GameEvents.OnSpinStarted);
    }

    private void Update()
    {
        UpdateLocalTime();
    }

    private void UpdateLocalTime()
    {
        _localTimeText.text = DateTime.Now.ToString();
    }
}

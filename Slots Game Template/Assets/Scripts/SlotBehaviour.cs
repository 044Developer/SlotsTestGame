using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SlotBehaviour : MonoBehaviour
{
    private const int MaxIconsCount = 15;

    [HideInInspector] public List<string> _currentCombination = new List<string>();

    [Header("Rows")]
    [SerializeField] private List<Image> _firstRow;
    [SerializeField] private List<Image> _secondRow;
    [SerializeField] private List<Image> _thirdRow;

    [Header("Colums")]
    [SerializeField] private List<Image> _firstColumn;
    [SerializeField] private List<Image> _secondColumn;
    [SerializeField] private List<Image> _thirdColumn;
    [SerializeField] private List<Image> _forthColumn;
    [SerializeField] private List<Image> _fifthColumn;

    [Header("DOTween Timers")]
    [SerializeField] private float _shakeLineTime;


    private void OnEnable()
    {
        GameEvents.SpinEnded += CheckColumnWinCondition;
        GameEvents.SpinEnded += CheckRowWinCondition;
    }

    private void CheckRowWinCondition()
    {
        if (_currentCombination.Count >= 14)
        {
            if (_currentCombination[0] == _currentCombination[3]
                    && _currentCombination[3] == _currentCombination[6]
                    && _currentCombination[6] == _currentCombination[9]
                    && _currentCombination[9] == _currentCombination[12])
            {
                ShakeWinLine(_firstRow);
            }

            if (_currentCombination[1] == _currentCombination[4]
                    && _currentCombination[4] == _currentCombination[7]
                    && _currentCombination[7] == _currentCombination[10]
                    && _currentCombination[10] == _currentCombination[13])
            {
                ShakeWinLine(_secondRow);
            }

            if (_currentCombination[2] == _currentCombination[5]
                    && _currentCombination[5] == _currentCombination[8]
                    && _currentCombination[8] == _currentCombination[11]
                    && _currentCombination[11] == _currentCombination[14])
            {
                ShakeWinLine(_thirdRow);
            }
        }
    }

    private void CheckColumnWinCondition()
    {
        if (_currentCombination.Count >= MaxIconsCount)
        {
            if (_currentCombination[0] == _currentCombination[1] && _currentCombination[1] == _currentCombination[2])
            {
                ShakeWinLine(_firstColumn);
            }

            if (_currentCombination[3] == _currentCombination[4] && _currentCombination[4] == _currentCombination[5])
            {
                ShakeWinLine(_secondColumn);
            }

            if (_currentCombination[6] == _currentCombination[7] && _currentCombination[7] == _currentCombination[8])
            {
                ShakeWinLine(_thirdColumn);
            }

            if (_currentCombination[9] == _currentCombination[10] && _currentCombination[10] == _currentCombination[11])
            {
                ShakeWinLine(_forthColumn);
            }

            if (_currentCombination[12] == _currentCombination[13] && _currentCombination[13] == _currentCombination[14])
            {
                ShakeWinLine(_fifthColumn);
            }
        }
    }

    private void ShakeWinLine(List<Image> _winLine)
    {
        for (int i = 0; i < _winLine.Count; i++)
        {
            _winLine[i].transform.DOShakeRotation(_shakeLineTime);
        }
    }

    private void OnDisable()
    {
        GameEvents.SpinEnded -= CheckColumnWinCondition;
        GameEvents.SpinEnded -= CheckRowWinCondition;
    }
}

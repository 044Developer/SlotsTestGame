using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotColumnController : MonoBehaviour
{
    [SerializeField] private SlotBehaviour _slotBehaviour;

    [SerializeField] private List<Image> _rows;
    [SerializeField] private List<Sprite> _slotIcons;

    [SerializeField] private int _timesToRoll;
    [SerializeField] private float _timeBtwRolls;

    private void OnEnable()
    {
        GameEvents.SpinStarted += StartSpinn;
    }

    private void Start()
    {
        InitializeColumn();
    }

    private void InitializeColumn()
    {
        GetRandomIcon();
    }

    private void StartSpinn()
    {
        StartCoroutine(StartGameLoop());
    }

    private IEnumerator StartGameLoop()
    {
        _slotBehaviour._currentCombination.Clear();
        GetRandomIcon();
        for (int i = 0; i < _timesToRoll; i++)
        {
            _rows[2].sprite = _rows[1].sprite;
            _rows[1].sprite = _rows[0].sprite;
            _rows[0].sprite = _slotIcons[RandomGeneratorHelper.GetRandomId(_slotIcons.Count)];
            yield return new WaitForSeconds(_timeBtwRolls);
        }
        AddCombinationToTotal();
    }

    private void AddCombinationToTotal()
    {
        for (int i = 0; i < _rows.Count; i++)
        {
            _slotBehaviour._currentCombination.Add(_rows[i].sprite.name);
        }
        GameEvents.OnSpinEnded();
    }

    private void GetRandomIcon()
    {
        for (int i = 0; i < _rows.Count; i++)
        {
            _rows[i].sprite = _slotIcons[RandomGeneratorHelper.GetRandomId(_slotIcons.Count)];
        }
    }

    private void OnDisable()
    {
        GameEvents.SpinStarted -= StartSpinn;
    }
}

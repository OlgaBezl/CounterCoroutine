using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _step = 0.5f; 
    [SerializeField] private float _increment = 1f;

    private float _currentValue = 0;
    private Coroutine _coroutine;
    private bool _isWork;

    public Action<float> Changed;

    public void StartOrPause()
    {
        _isWork = !_isWork;

        if(_isWork)
        {
            _coroutine = StartCoroutine(Count());
        }
        else
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(_step);

        while (_isWork)
        {
            _currentValue += _increment;
            Changed?.Invoke(_currentValue);

            yield return wait;
        }
    }
}

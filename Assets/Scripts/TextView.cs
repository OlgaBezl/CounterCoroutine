using TMPro;
using UnityEngine;

public class TextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.Changed += ChangeText;
    }

    private void OnDisable()
    {
        _counter.Changed -= ChangeText;
    }

    private void ChangeText(float value)
    {
        _text.text = value.ToString();
    }
}

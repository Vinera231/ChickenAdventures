using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Score _score;

    private void OnEnable()
    {
        _score.Changed += OnScoreChang;
        OnScoreChang();
    }

    private void OnDisable() => 
        _score.Changed -= OnScoreChang;
    
    public void OnScoreChang() =>
        _text.text = $"{_score.Value}";
}
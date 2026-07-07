using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private ScoreView _view;

    public event Action Changed;
    public event Action<int> BuyedIteam;

    public int Value => _amount;

    public void SetValue(int value)
    {
        _amount = value;
        Changed?.Invoke();
    }

    public void Increase(int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        _amount += amount;
        Changed?.Invoke();

        if (_view != null)
            _view.OnScoreChang();
    }

    public bool TrySpendScore(int value)
    {
        if (_amount < value)
        {
            SfXPlayer.Instance.PlayDontEnoughCoin();
            return false;
        }

        _amount -= value;


        BuyedIteam?.Invoke(value);
        Changed?.Invoke();
        if (_view != null)
            _view.OnScoreChang();

        return true;
    }
}
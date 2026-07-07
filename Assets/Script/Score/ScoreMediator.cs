using UnityEngine;

public class ScoreMediator : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private Player _player;

    private void OnEnable() =>
        _player.CoinCollected += OnCoinCollected;
      
    private void OnDisable() =>    
        _player.CoinCollected -= OnCoinCollected;    

    private void OnCoinCollected(int amount) => 
        _score.Increase(amount);  
}
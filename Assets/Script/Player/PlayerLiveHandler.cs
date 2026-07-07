using UnityEngine;

public class PlayerLiveHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameOverPanel _panel;
    [SerializeField] private InputReader _reader;

    private void OnEnable() =>    
        _player.Died += OnPlayerDied;
    
    private void OnDisable() =>
        _player.Died -= OnPlayerDied;

    private void OnPlayerDied()
    {
        _panel.Show();
        _reader.Disable();
        SfXPlayer.Instance.PlayDied();
    }
}
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private InputReader _reader;

    private void OnEnable() => 
        _reader.MovementChanged += OnMovementChanged;
      
    private void OnDisable() =>  
        _reader.MovementChanged -= OnMovementChanged;   

    private void OnMovementChanged() =>
        _renderer.flipX = _reader.Movement < 0; 
}
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private EnemyAnimation _animation;
    [SerializeField] private Enemy _enemy;

    private void OnEnable() =>
        _enemy.Moved += OnMovementChanged;

    private void OnDisable() =>
        _enemy.Moved -= OnMovementChanged;

    public void OnMovementChanged(float directionX)
    {
        if (directionX == 0)
        {
            _animation.PlayStay();
            return;
        }

        _renderer.flipX = directionX < 0;   
        _animation.PlayRun();
    }
}
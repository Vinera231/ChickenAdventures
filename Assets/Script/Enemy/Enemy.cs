using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Detector _detector;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _hight = 1.5f;

    public System.Action<float> Moved;
    private Transform _player;

    private void OnEnable()
    {
        _detector.Detected += OnColliderDetected;
        _detector.Missing += OnColliderMissing;
    }

    private void OnDisable()
    {
        _detector.Detected -= OnColliderDetected;
        _detector.Missing -= OnColliderMissing;
    }

    private void FixedUpdate() =>   
        Move();   

    public void Move()
    {
        if (_player == null)
            return;

        float directionY = Mathf.Abs(_player.position.y - transform.position.y);

        if(directionY > _hight)
        {
            _rigidbody.linearVelocity = new Vector2(0,_rigidbody.linearVelocity.y);
            Moved?.Invoke(0);
            return;
        }

        float direction = Mathf.Sign(_player.position.x - transform.position.x);
        _rigidbody.linearVelocity = new Vector2(direction * _speed, _rigidbody.linearVelocity.y);
        Moved?.Invoke(direction);
    }

    private void OnColliderDetected(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            _player = player.transform;
        }
    }

    private void OnColliderMissing(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player _))
        {
            _player = null;
            _rigidbody.linearVelocity = Vector2.zero;
        }
    }
}

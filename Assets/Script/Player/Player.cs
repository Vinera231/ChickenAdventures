using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;
    [SerializeField] private float _delayWalk;

    private int _groundCount;
    private float _currentWalkTime;
    private readonly List<AudioClip> _groundClips = new();

    public event Action<int> CoinCollected;
    public event Action Died;

    private void Awake() =>
        _rb.freezeRotation = true;

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IGround ground))
        {
            _groundClips.Add(ground.Audio);
            _groundCount++;

            SfXPlayer.Instance.PlayDrop();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IGround ground))
        {
            _groundClips.Remove(ground.Audio);
            _groundCount--;
        }
    }

    private void OnEnable() =>
        _reader.Jumped += OnJump;

    private void OnDisable() =>
        _reader.Jumped -= OnJump;

    public void CollectCoin(int amount)
    {
        CoinCollected?.Invoke(amount);
        SfXPlayer.Instance.PlayCoin();
    }
  
    private void PlayWalkSound()
    {
        if (_currentWalkTime <= 0)
        {
            if (_groundClips.Count > 0)
                SfXPlayer.Instance.PlayOneShot(_groundClips.Last());

            _currentWalkTime = _delayWalk;

            if (_currentWalkTime == 0)
                SfXPlayer.Instance.Stop();
        }

        _currentWalkTime -= Time.deltaTime;
    }

    private void Move()
    {
        _animation.PlayRun();
        float movement = _reader.Movement;
        Vector2 velocity = _rb.linearVelocity;
        velocity.x = movement * _speed;
        _rb.linearVelocity = velocity;

        if (movement != 0)
        {
            _animation.PlayRun();
            PlayWalkSound();
        }
        else       
            _animation.PlayIdle();       
    }

    private void OnJump()
    {
        if (_groundCount > 0)
        {
            SfXPlayer.Instance.PlayJump();
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jump);
            _animation.PlayIdle();
        }
    }

    public void Kill()
    {
        Died?.Invoke();
        MusicStop.Instance.StopPlayMusic();
    }
}
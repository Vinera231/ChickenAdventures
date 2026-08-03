using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private static readonly int s_attackAnimationID = Animator.StringToHash("RunPlayer");
    private static readonly int s_standAnimationID = Animator.StringToHash("IdlePlayer");

    [SerializeField] private Animator _animator;

    private bool _isRun;
    public void PlayRun()
    {
        if (_isRun)
            return;

        _isRun = true;
        _animator.Play(s_attackAnimationID, 0, 0);
    }
    public void PlayIdle()
    {
        if (!_isRun)
            return;

        _isRun = false;
        _animator.Play(s_standAnimationID, 0, 0);
    }
}
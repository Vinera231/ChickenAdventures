using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private static readonly int s_attackAnimationID = Animator.StringToHash("Run");
    private static readonly int s_standAnimationID = Animator.StringToHash("Ible");

    [SerializeField] private Animator _animator;

    private bool _isRunning;
    public void PlayRun()
    {
        if (_isRunning)
            return;

        _isRunning = true;
        _animator.Play(s_attackAnimationID, 0, 0);
    }

    public void PlayStay()
    {
        _isRunning = false;
        _animator.Play(s_standAnimationID, 0, 0);
    }
}
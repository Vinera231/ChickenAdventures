using UnityEngine;

public class WakeUpDogAnimation : MonoBehaviour
{
    private static readonly int s_WakeUpAnimationID = Animator.StringToHash("WakeUpDog");

    [SerializeField] private Animator _animator;

    public void PlayWakeUpDog() =>
        _animator.Play(s_WakeUpAnimationID, -1, 0);
}
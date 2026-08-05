using UnityEngine;

public class WakeUpDogAnimation : MonoBehaviour
{
    private static readonly int s_WakeUpAnimationID = Animator.StringToHash("WakeUpDog");
    private static readonly int s_sleepAnimationID = Animator.StringToHash("IdleDog");
    private static readonly int s_BarkingAnimationID = Animator.StringToHash("BarkingDog");

    [SerializeField] private Animator _animator;

    public void PlayWakeUpDog() =>
        _animator.Play(s_WakeUpAnimationID, -1, 0);

    public void PlaySleepDog() =>
        _animator.Play(s_sleepAnimationID, -1, 0);

    public void PlayBarkingDog() =>
        _animator.Play(s_BarkingAnimationID, -1, 0);
}
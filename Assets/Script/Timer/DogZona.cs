using System.Collections;
using UnityEngine;

public class DogZona : MonoBehaviour
{
    [SerializeField] private WakeUpDogAnimation _wake;
    [SerializeField] private float _sleepTime = 10f;
    [SerializeField] private float _cheerTime = 2f;

    private bool _isOn = true;
    private bool _isSleep;
    private WaitForSeconds _waitSleep;
    private WaitForSeconds _waitCheer;

    private void Awake()
    {
        _waitSleep = new(_sleepTime);
        _waitCheer = new(_cheerTime);
        StartCoroutine(Routine());
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            if (_isSleep == false)
            {
                SfXPlayer.Instance.PlayBarkSound();
                _wake.PlayBarkingDog();
                player.Kill();
            }
        }
    }

    private IEnumerator Routine()
    {
        while (_isOn)
        {
            _wake.PlaySleepDog();
            SfXPlayer.Instance.PlaySleepSound();
            _isSleep = true;

            yield return _waitSleep;

            _wake.PlayWakeUpDog();
            _isSleep = false;

            yield return _waitCheer;
        }
    }
}

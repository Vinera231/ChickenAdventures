using TMPro;
using UnityEngine;

public class TimerZona : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private WakeUpDogAnimation _wake;
    [SerializeField] private GameObject _dogDetecter;
    [SerializeField] private float _timer = 10f;

    private void Update()
    {
        _timer -= Time.deltaTime;

        if(_timer <= 0f)
        {
            SfXPlayer.Instance.PlaySleepSound();
            _wake.PlayWakeUpDog();
            _timer = 10f;
            _dogDetecter.SetActive(true);
        }
        else 
           _dogDetecter.SetActive(false);

        _text.text = _timer.ToString($"F1");
    }
}

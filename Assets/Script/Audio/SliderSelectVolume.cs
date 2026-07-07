using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderSelectVolume : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private float _delay;

    private Coroutine _coroutine;
    private WaitForSecondsRealtime _wait;

    private bool _isDragging;

    private void Awake() =>
        _wait = new(_delay);

    public void OnPointerUp(PointerEventData eventData) =>
        StopCoroutine();

    public void OnPointerDown(PointerEventData eventData)
    {
        _isDragging = false;
        StartCoroutine();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isDragging)
        {
            _isDragging = true;
            Routine();
        }
    }

    private void StartCoroutine()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(Routine());
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Routine()
    {
        while (true)
        {
            SfXPlayer.Instance.PlaySlider();
            yield return _wait;
        }
    }
}

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeModifier : MonoBehaviour
{
    private const float MinimumVolume = -80;
    private const float MaxVolume = 20;

    private const string Music = "Music";
    private const string Sound = "SFX";

    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Image _onSound;
    [SerializeField] private Image _offSound;
    [SerializeField] private Image _onMusic;
    [SerializeField] private Image _offMusic;

    private float _minimumValueSlider;
    private float _maximumValueSlider;
    private float _normolized;

    private void Start()
    {
        _minimumValueSlider = _musicSlider.minValue;
        _maximumValueSlider = _musicSlider.maxValue;

        OnChangedMusic(_musicSlider.value);
        OnChangedSound(_soundSlider.value);
    }

    private void OnEnable()
    {
        _musicSlider.onValueChanged.AddListener(OnChangedMusic);
        _soundSlider.onValueChanged.AddListener(OnChangedSound);
    }

    private void OnDisable()
    {
        _musicSlider.onValueChanged.RemoveListener(OnChangedMusic);
        _soundSlider.onValueChanged.RemoveListener(OnChangedSound);
    }

    private void OnChangedSound(float value)
    {
        SetLevel(Sound, value);
        _normolized = NormolizeValue(value);

        if (Mathf.Approximately(_normolized, 0))
        {
            _onSound.enabled = false;
            _offSound.enabled = true;
        }
        else
        {
            _onSound.enabled = true;
            _offSound.enabled = false;
        }
    }

    private void OnChangedMusic(float value)
    {
        SetLevel(Music, value);
        _normolized = NormolizeValue(value);

        if (Mathf.Approximately(_normolized, 0))
        {
            _onMusic.enabled = false;
            _offMusic.enabled = true;
        }
        else
        {
            _onMusic.enabled = true;
            _offMusic.enabled = false;
        }
    }

    private void SetLevel(string group, float value)
    {
        float level = ConvertVolumeToLevel(NormolizeValue(value));
        _mixer.SetFloat(group, level);
    }

    private float NormolizeValue(float value) =>
    Mathf.InverseLerp(_minimumValueSlider, _maximumValueSlider, value);

    private float ConvertVolumeToLevel(float value) =>
    value == 0 ? MinimumVolume : Mathf.Log10(value) * MaxVolume;
}
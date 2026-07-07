using UnityEngine;

public class SfXPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _dropSound;
    [SerializeField] private AudioClip _walkSound;
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _selectSound;
    [SerializeField] private AudioClip _diedSound;
    [SerializeField] private AudioClip _platformWalkSound;
    [SerializeField] private AudioClip _sliderSound;
    [SerializeField] private AudioClip _pickEggSound;
    [SerializeField] private AudioClip _stopMusicSound;
    [SerializeField] private AudioClip _dontEnoughCoinSound;

    public static SfXPlayer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
    }

    public void PlayJump() =>
         PlayOneShot(_jumpSound);

    public void Stop() =>
         _source.Stop();

    public void PlayDrop() => 
        PlayOneShot(_dropSound);

    public void PlayCoin() =>
        PlayOneShot(_coinSound);

    public void PlayClick() =>
        PlayOneShot(_clickSound);

    public void PlaySelect() =>
        PlayOneShot(_selectSound);

    public void PlayDied() =>
        PlayOneShot(_diedSound);
    
    public void PlaySlider() =>
        PlayOneShot(_sliderSound);
    
    public void PlayPickEgg() =>
        PlayOneShot(_pickEggSound);
  
    public void PlayDontEnoughCoin() =>
        PlayOneShot(_dontEnoughCoinSound);

    public void PlayOneShot(AudioClip audio) =>
        _source.PlayOneShot(audio);
}
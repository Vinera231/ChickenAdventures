using UnityEngine;

public class MusicStop : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;

    public static MusicStop Instance {  get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
    }

    public void StopPlayMusic() =>
        _musicSource.Stop();
}
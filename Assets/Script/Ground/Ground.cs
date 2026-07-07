using UnityEngine;

public class Ground : MonoBehaviour, IGround
{
    [SerializeField] private AudioClip _audio;

    AudioClip IGround.Audio => _audio;
}
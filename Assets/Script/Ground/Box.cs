using UnityEngine;

public class Box : MonoBehaviour, IGround
{
    [SerializeField] private AudioClip _audio;

    public AudioClip Audio => _audio;
}
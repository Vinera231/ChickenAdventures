using UnityEngine;

public class GameSceneBootstrap : MonoBehaviour
{
    [SerializeField] private InputReader _reader;

    private void Start()
    {
        _reader.Enable();
    }
}
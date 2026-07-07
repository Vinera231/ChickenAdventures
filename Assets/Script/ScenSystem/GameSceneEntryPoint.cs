using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private List<Coin> _coins;
    [SerializeField] private List<Egg> _eggs;

    private void Awake()
    {
        CursorShower.Instance.HideCursor();
    }
}
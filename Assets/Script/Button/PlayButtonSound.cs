using System;
using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;

    private void OnEnable()
    {
        _informer.Clicked += OnClick;
        _informer.Entered += OnSelect;
    }

    private void OnClick() =>   
        SfXPlayer.Instance.PlayClick();
    
    private void OnSelect() =>   
        SfXPlayer.Instance.PlaySelect();   
}
using System;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] private ButtonInformer _Informer;
    [SerializeField] private SettingPanel _setting;

    private void OnEnable()=>   
        _Informer.Clicked += OnSetting;
    
    private void OnDisable() =>
        _Informer.Clicked -= OnSetting;
    
    private void OnSetting() =>
        _setting.Show();
}
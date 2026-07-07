using System;
using UnityEngine;

public class SettingPanelShower : MonoBehaviour
{
    [SerializeField] private SettingPanel _settingPanel;
    [SerializeField] private InputReader _reader;
    [SerializeField] private ButtonClosePanel _closeButton;
    [SerializeField] private RestartButton _restart;

    private bool _isShower;

    private void OnEnable() =>   
        _reader.SettingOnShower += OnPanelPressed;

    private void OnDisable() =>    
        _reader.SettingOnShower -= OnPanelPressed;
    
    public void OnPanelPressed()
    {
        _isShower = !_isShower;

        if (_isShower)
            _settingPanel.Show();     
        else       
            _settingPanel.Hide();       
    }
}
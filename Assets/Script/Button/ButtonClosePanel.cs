using UnityEngine;

public class ButtonClosePanel : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;
    [SerializeField] private SettingPanel _settingPanel;

    public void OnEnable() =>
        _informer.Clicked += OnClick;

    public void OnDisable() =>
        _informer.Clicked -= OnClick;

    private void OnClick() =>  
        _settingPanel.Hide();   
}
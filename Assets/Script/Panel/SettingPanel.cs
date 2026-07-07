using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    private void OnEnable()
    {
        PauseSwitcher.Instance.Pause();
        CursorShower.Instance.ShowCursor();
    }

    private void OnDisable()
    {
        if (CursorShower.Destroyed == false)
            CursorShower.Instance.HideCursor();

        PauseSwitcher.Instance.Continue();
    }

    public void Show() =>
        gameObject.SetActive(true);

    public void Hide() =>
        gameObject.SetActive(false);

}

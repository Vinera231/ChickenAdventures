using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    private void OnEnable()
    {
        CursorShower.Instance.ShowCursor();
        PauseSwitcher.Instance.Pause();
    }

    private void OnDisable()
    {
        if (CursorShower.Destroyed == false)
            CursorShower.Instance.HideCursor();

        PauseSwitcher.Instance.Continue();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
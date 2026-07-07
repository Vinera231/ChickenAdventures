using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetProgress : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;

    private void OnEnable() =>
        _informer.Clicked += OnResetProgres;

    private void OnDisable() =>
        _informer.Clicked -= OnResetProgres;

    private void OnResetProgres()
    {
        CursorShower.Instance.ShowCursor();
        PauseSwitcher.Instance.Continue();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
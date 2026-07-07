using UnityEngine;

public class ExitGame: MonoBehaviour
{
    [SerializeField] private ButtonInformer _buttonInformer;

    private void OnEnable() =>
        _buttonInformer.Clicked += QuitGame;

    private void OnDisable() =>
      _buttonInformer.Clicked -= QuitGame;

    public void QuitGame() =>
    Application.Quit();
}
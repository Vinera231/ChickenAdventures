using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private ButtonInformer _buttonInformer;

    private void OnEnable() =>
        _buttonInformer.Clicked +=LoadGame;
   
    private void OnDisable() =>
        _buttonInformer.Clicked -=LoadGame;

    public void LoadGame() =>
    SceneManager.LoadScene(1);
}
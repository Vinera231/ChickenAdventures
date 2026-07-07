using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private ButtonInformer _informer;

    private void OnEnable() =>   
        _informer.Clicked += OnMenu;
    
    private void OnDisable() =>   
        _informer.Clicked -= OnMenu;

    private void OnMenu()
    {
        CursorShower.Instance.ShowCursor();
        SceneManager.LoadScene(0);
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangedLocation : MonoBehaviour
{
    [SerializeField] private int _sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))        
            SceneManager.LoadScene(_sceneToLoad);            
    }
}
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private GameObject _dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _dialog.SetActive(true);
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _dialog.SetActive(false);
    }
}

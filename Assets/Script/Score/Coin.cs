using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _amount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.CollectCoin(_amount);
            gameObject.SetActive(false);
        }
    }
}

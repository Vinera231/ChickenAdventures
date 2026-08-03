using UnityEngine;

public class GoldenEgg : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private GameObject _goldenEggImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.CollectCoin(_amount);
            _goldenEggImage.SetActive(true);
        }
    }
}
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private GameObject _eggInBirdNet;
    [SerializeField] private ShowPanelWin _panelWin;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.CollectCoin(_amount);
            gameObject.SetActive(false);
            _eggInBirdNet.SetActive(true);
            SfXPlayer.Instance.PlayPickEgg();
            _panelWin.AddEgg();
        }
    }
}
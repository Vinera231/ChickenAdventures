using UnityEngine;

public class BuyIteam : MonoBehaviour
{
    [SerializeField] private GameObject _iteam;
    [SerializeField] private GameObject _egginBirdNet;
    [SerializeField] private GameObject _dialog;
    [SerializeField] private GameObject _advicePanel;
    [SerializeField] private ShowPanelWin _panelWin;
    [SerializeField] private InputReader _reader;
    [SerializeField] private Score _score;
    [SerializeField] private int _price;

    private bool _isBuyind;

    public void OnEnable()
    {
        _reader.Buyed += OnBuy;
    }

    public void OnDisable()
    {
        _reader.Buyed -= OnBuy;
    }

    private void OnBuy()
    {
        if (_isBuyind)
            return;

        if (_score.TrySpendScore(_price))
        {
            _isBuyind = true;
            _iteam.SetActive(false);
            _dialog.SetActive(false);
            _advicePanel.SetActive(true);
            _egginBirdNet.SetActive(true);
            SfXPlayer.Instance.PlayPickEgg();
            _panelWin.AddEgg();
        }

    }
}
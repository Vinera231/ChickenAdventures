using UnityEngine;

public class ShowPanelWin : MonoBehaviour
{
    [SerializeField] public GameObject _panelWin;
    [SerializeField] public GameObject _advicePanel;
    

    private int _collectEgg = 0;
    private int _maxEgg = 3;

    public void AddEgg() =>   
        _collectEgg++;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_collectEgg >= _maxEgg)
        {
            _panelWin.SetActive(true);
            _advicePanel.SetActive(false);
            PauseSwitcher.Instance.Pause();
        }
    }
}


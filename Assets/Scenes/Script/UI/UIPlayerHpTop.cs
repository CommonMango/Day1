using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHpTop : MonoBehaviour, IPlayerHpObserver
{
    [SerializeField] private Image _imgHpBar;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.AddHPObserver(this);
    }
    private void OnDestroy()
    {
        _player.RemoveHPObserver(this);
    }
    public void OnPlayerHpChanged(float curHp, float maxHp)
    {
        _imgHpBar.fillAmount = curHp / maxHp;
    }
}

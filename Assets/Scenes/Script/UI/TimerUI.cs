using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour, IGameTimerObserver
{
    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] CheckTime _checkTime;

    private void Awake()
    {
        _checkTime.AddHPObserver(this);
    }

    private void OnDestroy()
    {
        _checkTime.RemoveHPObserver(this);
    }

    public void OnTimerChanged(float curTime)
    {
        //▽ 소수점 둘째자리까지만 표시 
        _timeText.text = string.Format("\"{0:N2}\"", curTime); 
    }

}

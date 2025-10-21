using System.Collections.Generic;
using UnityEngine;

public class CheckTime : MonoBehaviour
{
    private float curTime;
    private List<IGameTimerObserver> _timerObservers = new List<IGameTimerObserver>();
    public void AddHPObserver(IGameTimerObserver observer) => _timerObservers.Add(observer);
    public void RemoveHPObserver(IGameTimerObserver observer) => _timerObservers.Remove(observer);
    private void Awake()
    {       
        RegistTimer();
    }

    private void Start()
    {
        
        TimerInit();        
    }

    private void Update()
    {
        if(GameManager.Instance.isPlaying) //플레이중 이라면 
        {           
            curTime += Time.deltaTime; //시간 증가 
            NotifytimeUpdate();  
        }               
    }

    private void RegistTimer() 
    {
        GameManager.Instance.OnGameStartAction += TimerInit;
    }
   
    private void TimerInit() //타이머 초기화 
    {
        curTime = 0;
        NotifytimeUpdate();
    }

    private void NotifytimeUpdate() //시간 변경 알림
    {
        foreach (var observer in _timerObservers)
        {
            observer.OnTimerChanged(curTime); 
        }
    }


}

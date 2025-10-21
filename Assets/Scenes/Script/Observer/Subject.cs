using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    //구독자 리스트
    private List<IObserver> observers = new List<IObserver>();
    
    //구독, 해제기능
    public void AddObserver(IObserver observer) => observers.Add (observer);
    public void RemoveObserver(IObserver observer) => observers.Remove(observer);

   private void Start()
    {
        Notify();
    }

    private void Notify()
    {
        foreach(IObserver observer in observers)
        {
            observer.OnNotify();
        }
    }
}

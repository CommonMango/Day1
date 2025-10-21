using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExample : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _subject;

    private void Awake()
    {
        _subject?.AddObserver(this);
    }

    //순환참조가 생길 수 있으므로 잊어버리지 않기 
    private void OnDestroy()
    {
        _subject?.RemoveObserver(this);
    }

    //인터페이스에 약속된 함수
    public void OnNotify()
    {
        Debug.Log($"난 받고 싶지 않았어..");
    }
}



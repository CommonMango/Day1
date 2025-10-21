using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AExampleForObserver : MonoBehaviour, IObserver
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
        Debug.Log($"{gameObject.name} Received");
    }
}

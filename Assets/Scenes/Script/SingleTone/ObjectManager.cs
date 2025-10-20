using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectManager<T> where T : MonoBehaviour
{
    [field: SerializeField] public UnityEvent OnManagerCalled { get; private set; } = new UnityEvent();
    void Start()
    {
        
    }
   
    void Update()
    {
        CallManager();
    }

    private void CallManager()
    {
        OnManagerCalled?.Invoke();
    }

    private T GenerateObject(T prefab)
    {
        T obj = Instantiate(prefab);
        return obj;
    }

    private void DeleteObject(GameObject obj)
    {

    }
}

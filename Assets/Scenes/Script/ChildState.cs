using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Android.Types;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    [SerializeField] private string _hiTxt;
    [SerializeField] private GameObject _target;
    void Awake()
    {
        Init();
    }

    private void Start()
    {
        PrintChildHi();       
    }

    private void Init()
    {
        if(_target != null)
        {
            _target.transform.SetParent(transform);
        }      
    }

    void PrintChildHi()
    {
        ChildComponent[] childComs = transform.GetComponentsInChildren<ChildComponent>();

        int index = 0;

        foreach (ChildComponent child in childComs)
        {
            child.name = $"child - {index++}";
            child.PrintHi();
        }
    }
}

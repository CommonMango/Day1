using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
  
    void Awake()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name}호출");
    }
    void OnEnable()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name}호출");
    }
    void Start()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name}호출");
    }

    void Update()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name}호출");
    }

    private void FixedUpdate()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name}호출");
    }

    private void LateUpdate()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name}호출");
    }
    private void OnDisable()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name}호출");
    }
    private void OnDestroy()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name}호출");
    }
}

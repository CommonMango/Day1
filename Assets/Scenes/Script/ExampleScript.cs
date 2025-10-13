using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
   
    void Start()
    {
        Debug.Log("게임 시작");
    }

    
    void Update()
    {
        //Debug.Log("업데이트");
    }

    private void OnDisable()
    {
        Debug.Log("비활성화");
    }
}

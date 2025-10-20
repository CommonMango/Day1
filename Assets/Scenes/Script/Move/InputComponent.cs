using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private float _horiInput;
    private float _vertInput;
    

    public float HoriInput => _horiInput;
    public float VertInput => _vertInput;
    

    void Update()
    {
        _horiInput = Input.GetAxisRaw("Horizontal");
        _vertInput = Input.GetAxisRaw("Vertical");
       
        
    }
}

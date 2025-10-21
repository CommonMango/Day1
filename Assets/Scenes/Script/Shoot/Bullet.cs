using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float _shotForce = 20;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {           
        _rigidbody.velocity = Vector3.zero; //속도 제거 
        _rigidbody.angularVelocity = Vector3.zero; //회전 속도 제거 
    
        ShootAction();    
    }

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) //trigger가 작동하면 삭제 
    {        
        gameObject.SetActive(false);
    }

    private void ShootAction()
    {         
        _rigidbody.AddForce(transform.forward * _shotForce, ForceMode.Impulse);       
    }    
}

using System.Collections;
using System.Collections.Generic;
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
        ShootAction();    
    }

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

    private void ShootAction()
    {
        _rigidbody.AddForce(transform.forward * _shotForce, ForceMode.Impulse);       
    }    
}

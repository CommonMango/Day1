using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   
    [SerializeField]private GameObject bulletObject; //발사될 총알 
    [SerializeField] private float firerate; //발사 간격 
    [SerializeField] private int _bulletPoolSize; //오브젝트 풀 사이즈 

    private Queue<GameObject> _bulletPool = new Queue<GameObject>();
             
    void Awake()
    {
        Init();         
    }
   
    private void Init()
    {       
        _bulletPool = new Queue<GameObject>();

        for (int i = 0; i < _bulletPoolSize; i++)
        {
            GameObject gameObject = Instantiate(bulletObject);
            gameObject.SetActive(false);
            _bulletPool.Enqueue(gameObject);
        }
    }
    
    public void ShootBullet()
    {
        foreach(var bullet in _bulletPool)
        {
            if(bullet.activeSelf == false)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                return;
            }
        }
        
    }

    
         
}

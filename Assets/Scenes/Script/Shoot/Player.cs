using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject playerWeapon;
    [SerializeField] private int playerMaxHp;
    [SerializeField] private int playerCurHp; //플레이어 현재 체력

    Weapon BulletShooter;

    private void Start()
    {
        BulletShooter = playerWeapon.GetComponent<Weapon>();
        playerCurHp = playerMaxHp;
    }
    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Space))
        {          
            BulletShooter.ShootBullet();            
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            playerCurHp -= 10;
            if (playerCurHp <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

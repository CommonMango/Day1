using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletObject; // 발사될 총알 
    [SerializeField] private float _fireRate = 0.2f;   // 발사 간격

    private WaitForSeconds _firedelay;

    private void Start()
    {
        _firedelay = new WaitForSeconds(_fireRate);
    }

    public void StartShooting()
    { 
       StartCoroutine(Shooting());
    }  

    private IEnumerator Shooting()
    {       
        ObjectManager.Instance.Spawn(_bulletObject, transform.position, transform.rotation);           
        yield return _firedelay;       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _startPostion;
    [SerializeField] private GameObject _playerWeapon;
    [SerializeField] private int _playerMaxHp = 100;
    
    private int _playerCurHp; //플레이어 현재 체력
    private Weapon _BulletShooter;
    private List<IPlayerHpObserver> _hpObservers = new List<IPlayerHpObserver>();
    public void AddHPObserver(IPlayerHpObserver observer) => _hpObservers.Add(observer);
    public void RemoveHPObserver(IPlayerHpObserver observer) => _hpObservers.Remove(observer);
    
    private void Awake()
    {
        RegistPlayer();
    }

    private void Start()
    {
        _BulletShooter = _playerWeapon.GetComponent<Weapon>();
        InitPlayer();
    }
    private void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Space))
        {          
            _BulletShooter.StartShooting();            
        }       
    }

    private void InitPlayer()
    {
        _playerCurHp = _playerMaxHp;
        transform.position = _startPostion.position;
        gameObject.SetActive(true);
        NotifyHpUpdate();
    }

    private void RegistPlayer()
    {
        GameManager.Instance.OnGameStartAction += InitPlayer;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        _playerCurHp -= 10;
        NotifyHpUpdate();

        if (_playerCurHp <= 0)
        {
            _playerCurHp = 0;
            GameManager.Instance.ChangeGameState();
            gameObject.SetActive(false);
        }        
    }

    private void NotifyHpUpdate()
    {
        foreach (IPlayerHpObserver observer in _hpObservers)
        {
            observer.OnPlayerHpChanged(_playerCurHp, _playerMaxHp);
        }
    }
    

}

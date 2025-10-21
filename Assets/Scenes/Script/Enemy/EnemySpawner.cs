
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy; //적 프리팹
    [SerializeField] private int _enemyPoolSize;//풀 사이즈 지정 
    [SerializeField] private float _spawnDelay; // 적 스폰 딜레이 지정

    private GameObject[] _enemyPool;
    private WaitForSeconds _delay;

    private void Start()
    {
        Init();
        StartCoroutine(SpawnEnemy());
    }

    private void Init() //초기화 함수
    {
        _delay = new WaitForSeconds(_spawnDelay);                   
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            ObjectManager.Instance.Spawn(_enemy, transform.position, transform.rotation);
            yield return _delay;                           
        }
                
    }
}


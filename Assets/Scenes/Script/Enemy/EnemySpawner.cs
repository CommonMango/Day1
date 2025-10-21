
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject>_enemies; //적 프리팹
    [SerializeField] private float _spawnDelay; // 적 스폰 딜레이 지정

    private GameObject _targetEnemy; //생성할 적 
    private WaitForSeconds _delay; //생성 시간 

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
            int result = Random.Range(0, _enemies.Count);
            _targetEnemy = _enemies[result];
            
            ObjectManager.Instance.Spawn(_targetEnemy, transform.position, transform.rotation);
            yield return _delay;                           
        }
                
    }
}


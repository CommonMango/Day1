
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
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
        _enemyPool = new GameObject[_enemyPoolSize];

        for (int i = 0; i < _enemyPoolSize; i++) //오브젝트풀 생성
        {
            GameObject gameObject = Instantiate(_enemy);
            _enemyPool[i] = gameObject;
            _enemyPool[i].SetActive(false);
            
        }
    }

    private IEnumerator SpawnEnemy()
    {      
            foreach (var enemy in _enemyPool)
            {
                if (enemy.activeSelf == false) //비활성화된 적을 가져와 활성화 
                {
                    enemy.transform.position = transform.position;
                    enemy.transform.rotation = transform.rotation;
                    enemy.SetActive(true);
                    yield return _delay;                           
                }
        }
    }
}

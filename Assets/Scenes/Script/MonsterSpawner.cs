using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    //몬스터 프리펩
    [SerializeField] private GameObject _monsterPrefab;

    //몬스터 생성시 위치와 범위 
    [SerializeField] private int _spawnDistance;

    //몬스터 생성 갯수
    [SerializeField] private int _spawnCount;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) ;    
    }

    private void SpawnObj()
    {
        for(int i = 0; i < _spawnCount; i ++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-_spawnDistance, _spawnDistance),
                0f,
                Random.Range(-_spawnDistance, _spawnDistance));
        }
    }
}

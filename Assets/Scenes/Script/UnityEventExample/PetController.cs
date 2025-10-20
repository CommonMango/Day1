using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    [SerializeField] private PlayerController _players;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveStopDistance;

    private Coroutine _moveCoroutine;   

    //플레이어의 유니티 이벤트에 연결해줄 코루틴 실행 함수, 코루틴이 중복 실행되지 않도록 조건 추가함 
    public void MoveToPlayer()
    {
        if (_moveCoroutine == null)
        {
            _moveCoroutine = StartCoroutine(MoveToTarget(_players.transform));
        }
    }

    //플레이어를 따라서 이동하는데 정해진 간격까지 이동하면 멈추도록 하는 코루틴 함수 
    private IEnumerator MoveToTarget(Transform target)
    {
        while (true)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);

            if (distance <= _moveSpeed)
            {
                _moveCoroutine = null;
                yield break;
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                _moveSpeed * Time.deltaTime
                );
            yield return null;
        }
    }
}

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _maxDeactiveCount;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject target;

    private int _currentDeactiveCount;
    
    Vector3 _position;

    private void OnEnable()
    {
        Init();
    }

    private void Update()
    {
        MoveObject();
    }

    private void Init()
    {       
        _currentDeactiveCount = _maxDeactiveCount; //현재 체력을 최대로 초기화
        _position = transform.position;
        transform.LookAt(new Vector3(target.transform.position.x,_position.y,target.transform.position.y)); //현재 y좌표는 그대로 target을 바라보게 한다.         
    }

    private void MoveObject()
    {
        
        transform.position += transform.forward * _moveSpeed * Time.fixedDeltaTime;
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Wall") || collider.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

        if (collider.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }


    private void TakeDamage()
    {
        _currentDeactiveCount--;
        if(_currentDeactiveCount <= 0)
        {            
            gameObject.SetActive(false);
        }
    }
}

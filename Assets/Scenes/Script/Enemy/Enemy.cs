using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _maxDeactiveCount;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject _wall;

    private int _currentDeactiveCount;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        MoveObject();        
    }


    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentDeactiveCount = _maxDeactiveCount;
        transform.LookAt(_wall.transform);
    }
    
    private void MoveObject()
    {
        transform.position += transform.forward * _moveSpeed * Time.fixedDeltaTime;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }      
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
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

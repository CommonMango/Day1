using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(InputComponent))]
public class MoveComponent : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 20;
    [SerializeField] private GameObject _movingPlane;
    [SerializeField] private float _xBoundValue;
    [SerializeField] private float _zBoundValue;

    private InputComponent _inputComponent;
    private Vector3 _minWorldBounds;
    private Vector3 _maxWorldBounds;
    private Vector3 _playerExtents;

    private void Start()
    {
        _inputComponent = GetComponent<InputComponent>();

        SphereCollider playerColider = GetComponent<SphereCollider>();

        if (playerColider != null)
        {
            _playerExtents = playerColider.bounds.extents;
        }

        if (_movingPlane != null)
        {
            Bounds planeBounds = _movingPlane.GetComponent<MeshRenderer>().bounds;
            _minWorldBounds = planeBounds.center - planeBounds.extents;
            _maxWorldBounds = planeBounds.center + planeBounds.extents;

        }
    }

    private void Update()
    {
        Move();    
    }

    private void Move()
    {
        //현재 게임이 진행중인지 체크 
        if (GameManager.Instance.isPlaying == false)
            return;

        Vector3 inputVec = new Vector3(_inputComponent.HoriInput, 0f, _inputComponent.VertInput).normalized;
        Vector3 deltaMovement = _moveSpeed * Time.deltaTime * inputVec;
        Vector3 nextPosition = transform.position + deltaMovement;

        float xGap = _xBoundValue * _playerExtents.x;
        float zGap = _zBoundValue * _playerExtents.z;

        nextPosition.x = Mathf.Clamp(nextPosition.x, _minWorldBounds.x + _playerExtents.x + xGap, _maxWorldBounds.x - _playerExtents.x - xGap);
        nextPosition.z = Mathf.Clamp(nextPosition.z, _minWorldBounds.z + _playerExtents.z + zGap, _maxWorldBounds.z - _playerExtents.z - zGap);
        
        transform.position = nextPosition;
        
    }
}

using System;
using UnityEngine;

public class Patrol_Cube : MonoBehaviour
{
    private enum PatrolState
    {
        Idle,
        Patrolling
    }

    private enum PatrolDirection
    {
        Left,
        Right,
        Top,
        Bottom
    }

    [SerializeField] private Move_Cube MoveComponent;

    public event Action OnStoppedMoving;
    public event Action<int> OnStartedMoving;

    private PatrolState _patrolState;
    private PatrolDirection _patrolDirection;
    private PatrolData_Cube _patrolData;

    private float _idleTimer;
    private float _moveTimer;
    private bool _isPatrolling;

    public void StartPatrolling(PatrolData_Cube patroData)
    {
        _patrolData = patroData;
        _isPatrolling = true;
        _idleTimer = 0;
        _moveTimer = 0;
        _patrolState = PatrolState.Idle;
    }

    public void StopPatrolling()
    {
        MoveComponent.Direction = Vector3.zero;
        MoveComponent.Speed = 0;
        OnStoppedMoving?.Invoke(); //Action
        _isPatrolling = false;
    }

    private void Update()
    {
        if (!_isPatrolling) return;

        switch (_patrolState)
        {
            default:
            case PatrolState.Idle:
                _idleTimer += Time.deltaTime;
                if (_idleTimer >= _patrolData.IdleDuration)
                {
                    PatrolMovimentDirection();
                    OnStartedMoving?.Invoke(((int)_patrolDirection)); //Action
                    MoveComponent.Speed = _patrolData.MoveSpeed;
                    _idleTimer = 0;
                }
                break;

            case PatrolState.Patrolling:
                _moveTimer += Time.deltaTime;

                if (_moveTimer >= _patrolData.MovelDuration)
                {
                    _patrolState = PatrolState.Idle;
                    _moveTimer = 0;
                    OnStoppedMoving?.Invoke(); //Action
                    MoveComponent.Speed = 0;
                }
                break;
        }
    }

    private void PatrolMovimentDirection()
    {
        //Patrol direction
        switch (_patrolDirection)
        {
            case PatrolDirection.Right:
                //Debug.Log("Direita");
                _patrolDirection = PatrolDirection.Top;
                MoveComponent.Direction = Vector3.right;
                break;

            case PatrolDirection.Top:
                //Debug.Log("Cima");
                _patrolDirection = PatrolDirection.Left;
                MoveComponent.Direction = Vector3.forward;
                break;

            case PatrolDirection.Left:
                //Debug.Log("Esquerda");
                _patrolDirection = PatrolDirection.Bottom;
                MoveComponent.Direction = Vector3.left;
                break;

            case PatrolDirection.Bottom:
                //Debug.Log("Baixo");
                _patrolDirection = PatrolDirection.Right;
                MoveComponent.Direction = Vector3.back;
                break;
        }
    }
}

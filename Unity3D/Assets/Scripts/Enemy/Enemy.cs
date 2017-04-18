using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Humanoid
{

    private StateMachine _stateMachine;
    private EnemyAttack _attackState;
    private EnemyMovement _movementState;



    private void Awake()
    {
        _stateMachine = GetComponent<StateMachine>();
        _attackState = GetComponent<EnemyAttack>();
        _movementState = GetComponent<EnemyMovement>();

    }

    private void Start()
    {
        _stateMachine.AddState("moving", _movementState);
        _stateMachine.AddState("attacking", _attackState);
        _stateMachine.SetState("moving");


    }

    private void Update()
    {
        if (_movementState._distance <= 5f)
        {
            _stateMachine.SetState("attacking");
        }
    }


}

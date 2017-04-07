﻿using System.Collections;
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
        _stateMachine.AddState("attacking", _attackState);
        _stateMachine.AddState("moving", _movementState);
        _stateMachine.SetState("moving");
    }


}

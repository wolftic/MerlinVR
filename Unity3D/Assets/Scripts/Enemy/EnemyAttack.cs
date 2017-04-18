using System.Collections;
using UnityEngine;

public class EnemyAttack : State
{
    private float _damage;
    public Tower Tower;

    public override void Enter()
    {
        _damage = 5f;
    }

    private void Attack()
    {
        StartCoroutine(Tower.DealDamage(_damage));
    }

    public override void StateUpdate()
    {
        Attack();
    }

    public override void Exit()
    {

    }
}

using UnityEngine;

public class EnemyAttack : State
{
    private float _damage;
    public Tower Tower;
    public override void Enter()
    {
        _damage = 5f;

    }

    public override void StateUpdate()
    {
        Tower.DealDamage(_damage);
    }

    public override void Exit()
    {

    }
}

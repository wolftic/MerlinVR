using UnityEngine;

public class EnemyAttack : State
{

    private float _damage;
    public override void Enter()
    {
        _damage = 50f;
    }

    public override void StateUpdate()
    {

    }

    public override void Exit()
    {

    }
}

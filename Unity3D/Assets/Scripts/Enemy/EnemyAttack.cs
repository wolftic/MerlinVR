using System.Collections;
using UnityEngine;

public class EnemyAttack : State
{
    [SerializeField]
    private float _damage;
    private Tower _tower;

    private float _lastAttack;


    [SerializeField]
    private float _attackDelay;


    public float Damage
    {
        get
        {
           return _damage;
        }
        set
        {
           _damage = value;
        }
    }

    public override void Enter()
    {
        _tower = GameObject.FindObjectOfType<Tower>();
    }

    private void Attack()
    {
        _tower.DealDamage(_damage);
        GetComponent<Animator>().SetTrigger("Attack");
    }

    public override void StateUpdate()
    {
        if (_lastAttack < Time.time)
        {
            Attack();
            _lastAttack = Time.time + _attackDelay;
        }
    }

    public override void Exit()
    {

    }
}

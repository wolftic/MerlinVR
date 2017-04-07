using UnityEngine;

public class EnemyMovement : State
{

    private float _speed;
    [SerializeField] private Transform _target;

    public override void Enter()
    {
        _speed = 4f;
    }

    public override void StateUpdate()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
    }

    public override void Exit()
    {

    }
}

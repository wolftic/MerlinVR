using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : State
{

    private float _speed;
    [SerializeField] public Transform _target;
    private NavMeshAgent _navMeshAgent;
    [HideInInspector] public float _distance;

    public override void Enter()
    {
        _distance = Vector3.Distance(_target.position, transform.position);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _speed = 7f;
        _navMeshAgent.speed = _speed;
        _navMeshAgent.acceleration = _speed * 1.5f;
        _navMeshAgent.destination = _target.position;
    }

    public override void StateUpdate()
    {
        _distance = Vector3.Distance(_target.position, transform.position);
    }

    public override void Exit()
    {
        _navMeshAgent.GetComponent<NavMeshAgent>().enabled = false;
    }
}

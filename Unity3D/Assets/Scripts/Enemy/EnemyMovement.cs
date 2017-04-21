using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : State
{

    private float _speed;
    private Tower _tower;
    private NavMeshAgent _navMeshAgent;

    public float Distance
    {
        get;
        private set;
    }

    public override void Enter()
    {
        _tower = GameObject.FindObjectOfType<Tower>();

        Distance = Vector3.Distance(_tower.transform.position, transform.position);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _speed = 7f;
        _navMeshAgent.speed = _speed;
        _navMeshAgent.acceleration = _speed * 1.5f;
        _navMeshAgent.destination = _tower.transform.position;
    }

    public override void StateUpdate()
    {
        var pos = _tower.transform.position;
        pos.y = transform.position.y;
        Distance = Vector3.Distance(pos, transform.position);
    }

    public override void Exit()
    {
        _navMeshAgent.GetComponent<NavMeshAgent>().enabled = false;
    }
}

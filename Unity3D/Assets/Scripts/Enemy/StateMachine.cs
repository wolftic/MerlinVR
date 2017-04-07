using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    Dictionary<string, State> _states = new Dictionary<string, State>();


    private State _currentstate;


    private void Awake(){}
    private void Start(){}

    private void Update()
    {
        if (_currentstate == null)
        {
            return;
        }
        _currentstate.StateUpdate();
    }

    public void AddState(string name, State state)
    {
        _states.Add(name, state);
    }

    public void SetState(string name)
    {

        if (!_states.ContainsKey(name))
        {
            return;
        }

        if (_currentstate != null)
        {
            _currentstate.Exit();
        }

        _currentstate = _states[name];
        _currentstate.Enter();
    }


}

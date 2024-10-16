using UnityEngine;
using System.Collections.Generic;

public class AbstractStateMachine : MonoBehaviour
{
    IState _currentState;
    public IState CurrentState => _currentState;
    protected List<IState> _states = new List<IState>();

    [SerializeField, Header("Current State")]
    protected MonoBehaviour CurrentMonoState;
    protected bool _InTransition { get; private set; }

    void Awake() => AddStates();

    void AddStates()
    {
        IState[] stateComponents = GetComponents<IState>();
        for (int i = 0; i < stateComponents.Length; i++)
            _states.Add(stateComponents[i]);
    }

    public void ChangeState<T>() where T : IState
    {
        T targetState = GetComponent<T>();

        if (targetState == null)
            return;

        InitiateCurrentState(targetState);
    }

    void InitiateCurrentState(IState state)
    {
        if (_currentState != state && !_InTransition)
            Transition(state);
    }

    void Transition(IState nextState)
    {
        CurrentMonoState = (MonoBehaviour)nextState;
        _InTransition = true;

        _currentState?.OnStateExit();
        _currentState = nextState;
        _currentState.OnStateEntered();

        _InTransition = false;
    }

    void Update()
    {
        if (_currentState != null && !_InTransition)
            _currentState.OnStateExecute();
    }
}
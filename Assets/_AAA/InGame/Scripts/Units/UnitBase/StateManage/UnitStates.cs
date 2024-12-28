using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class UnitStates : MonoBehaviour
{
    private const int _maxStateCount = 10;
    public List<StateType> _unitStates = new (_maxStateCount);

    public List<StateType> UnitStatesList => _unitStates;

    public Action<StateType> OnStateAdded;
    public Action<StateType> OnStateRemoved;

    private void OnEnable()
    {
        _unitStates.Clear();
    }

    public void AddState(StateType state)
    {
        if (_unitStates.Count >= _maxStateCount)
            return;

        if (_unitStates.Contains(state))
            return;

        _unitStates.Add(state);
        OnStateAdded?.Invoke(state);
    }

    public void RemoveState(StateType state)
    {
        if (!_unitStates.Contains(state))
            return;

        _unitStates.Remove(state);
        OnStateRemoved?.Invoke(state);
    }

    public bool HasState(StateType state) => _unitStates.Contains(state);
}
